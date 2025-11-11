
using Microsoft.EntityFrameworkCore;
using Dominio;
using DTOs;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Repository
{
    public class GastoRepository
    {
        private TPIContext CreateContext() => new TPIContext();

        public void Add(Gasto gasto)
        {
            using var ctx = CreateContext();
            ctx.Gastos.Add(gasto);
            ctx.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var ctx = CreateContext();
            var g = ctx.Gastos.Find(id);
            if (g == null) return false;
            ctx.Gastos.Remove(g);
            ctx.SaveChanges();
            return true;
        }

        public Gasto? Get(int id)
        {
            using var ctx = CreateContext();
            return ctx.Gastos
                      .Include(g => g.CategoriaGasto)
                      .Include(g => g.Usuario)
                      .Include(g => g.Tarea) 
                      .FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Gasto> GetAll()
        {
            using var ctx = CreateContext();
            return ctx.Gastos
                .Include(g => g.CategoriaGasto)
                .Include(g => g.Usuario)
                .Include(g => g.Tarea) 
                .ToList();
        }

        public bool Update(Gasto gasto)
        {
            using var ctx = CreateContext();
            var existing = ctx.Gastos.Find(gasto.Id);
            if (existing == null) return false;
            existing.SetCategoriaGastoId(gasto.CategoriaGastoId);
            existing.SetUsuarioId(gasto.UsuarioId);
            existing.SetMonto(gasto.Monto);
            existing.SetDescripcion(gasto.Descripcion);
            existing.SetFechaHora(gasto.FechaHora);
            existing.SetFechaAlta(gasto.FechaAlta);
            existing.SetTareaId(gasto.TareaId);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Gasto> GetByCriteria(string texto)
        {
            using var ctx = CreateContext();
            if (string.IsNullOrWhiteSpace(texto))
                return ctx.Gastos
                    .Include(g => g.CategoriaGasto)
                    .Include(g => g.Usuario)
                    .Include(g => g.Tarea)
                    .ToList();

            texto = texto.ToLower();
            return ctx.Gastos
                .Include(g => g.CategoriaGasto)
                .Include(g => g.Usuario)
                .Include(g => g.Tarea) 
                .Where(g => g.Descripcion.ToLower().Contains(texto)
                            || g.Monto.ToString().Contains(texto)
                            || (g.CategoriaGasto != null && g.CategoriaGasto.Tipo.ToLower().Contains(texto))
                            || (g.Usuario != null && g.Usuario.Nombre.ToLower().Contains(texto))
                            || (g.Tarea != null && g.Tarea.Nombre.ToLower().Contains(texto)))
                .ToList();
        }

        public decimal GetTotalGastadoPorUsuarioEnGrupo(int usuarioId, int grupoId)
        {
            using var ctx = CreateContext();

            return ctx.Gastos
                .Where(g => g.UsuarioId == usuarioId &&
                           g.Tarea != null &&
                           g.Tarea.Plan != null &&
                           g.Tarea.Plan.GrupoId == grupoId)
                .Sum(g => (decimal)g.Monto);
        }
        public ReporteGastosGrupoDto GetReporteByGrupoId(int grupoId)
        {
            var reporte = new ReporteGastosGrupoDto
            {
                FechaGeneracion = DateTime.Now,
                GastosUsuarios = new List<ReporteGastosUsuarioDto>()
            };

            using (SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS;
                                Initial Catalog=Planificador;
                                Integrated Security=true;
                                TrustServerCertificate=True"))
            {
                con.Open();

                // obtengo nombre del grupo
                string sqlGrupo = @"
            SELECT Nombre 
            FROM Grupos 
            WHERE Id = @grupoId";

                using (SqlCommand cmd = new SqlCommand(sqlGrupo, con))
                {
                    cmd.Parameters.AddWithValue("@grupoId", grupoId);
                    var nombreGrupo = cmd.ExecuteScalar();
                    reporte.NombreGrupo = nombreGrupo?.ToString() ?? $"Grupo_{grupoId}";
                }
                //obtengo gastos por usuario
                string sql = @"
            SELECT 
                u.Id AS UsuarioId,
                u.Nombre AS UsuarioNombre,
                u.Mail AS UsuarioMail,
                SUM(gas.Monto) AS TotalGastado
            FROM Gastos gas
            INNER JOIN Tareas tar ON gas.TareaId = tar.Id
            INNER JOIN Planes p ON tar.PlanId = p.Id
            INNER JOIN Usuarios u ON u.Id = gas.UsuarioId
            WHERE p.GrupoId = @grupoId
            GROUP BY u.Id, u.Nombre, u.Mail
            ORDER BY SUM(gas.Monto) DESC;
        ";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@grupoId", grupoId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            reporte.GastosUsuarios.Add(new ReporteGastosUsuarioDto
                            {
                                NombreUsuario = dr.GetString(dr.GetOrdinal("UsuarioNombre")),
                                MailUsuario = dr.IsDBNull(dr.GetOrdinal("UsuarioMail"))
                                    ? ""
                                    : dr.GetString(dr.GetOrdinal("UsuarioMail")),
                                TotalGastado = Convert.ToDecimal(dr["TotalGastado"])

                            });
                            Debug.WriteLine(reporte.GastosUsuarios);
                        }
                    }
                }
            }
            Debug.WriteLine($"Total del grupo: {reporte.TotalGrupo}");

            
            return reporte.GastosUsuarios.Any() ? reporte : null;
        }
        public IEnumerable<GastoDTO> GetByGrupoId(int grupoId)
        {
            var lista = new List<GastoDTO>();

            using (SqlConnection con = new SqlConnection(@"Server=localhost\SQLEXPRESS;
                                Initial Catalog=Planificador;
                                Integrated Security=true;
                                TrustServerCertificate=True"))
            {
                con.Open();

                string sql = @"
            SELECT 
                gas.Id,
                gas.CategoriaGastoId,
                cat.Tipo AS CategoriaGastoNombre,
                gas.TareaId,
                tar.Nombre AS TareaNombre,
                gas.UsuarioId,
                u.Nombre AS UsuarioNombre,
                u.Mail AS UsuarioMail,
                gas.Monto,
                gas.Descripcion,
                gas.FechaHora,
                gas.FechaAlta
            FROM Gastos gas
            INNER JOIN Tareas tar ON gas.TareaId = tar.Id
            INNER JOIN CategoriaGastos cat ON cat.Id = gas.CategoriaGastoId
            INNER JOIN Usuarios u ON u.Id = gas.UsuarioId
            INNER JOIN Planes p ON tar.PlanId = p.Id
            WHERE p.GrupoId = @grupoId
            ORDER BY gas.FechaHora DESC;
        ";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@grupoId", grupoId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new GastoDTO
                            {
                                Id = dr.GetInt32(dr.GetOrdinal("Id")),
                                CategoriaGastoId = dr.GetInt32(dr.GetOrdinal("CategoriaGastoId")),
                                CategoriaGastoNombre = dr.GetString(dr.GetOrdinal("CategoriaGastoNombre")),
                                TareaId = dr.GetInt32(dr.GetOrdinal("TareaId"))
                                    ,
                                TareaNombre = dr.GetString(dr.GetOrdinal("TareaNombre")),
                                UsuarioId = dr.GetInt32(dr.GetOrdinal("UsuarioId")),
                                UsuarioNombre = dr.GetString(dr.GetOrdinal("UsuarioNombre")),
                                UsuarioMail=dr.GetString(dr.GetOrdinal("UsuarioMail")),
                                   
                                Monto = (float)dr.GetFloat(dr.GetOrdinal("Monto")),
                                Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion"))
                                    ? ""
                                    : dr.GetString(dr.GetOrdinal("Descripcion")),
                                FechaHora = dr.GetDateTime(dr.GetOrdinal("FechaHora")),
                                FechaAlta = dr.GetDateTime(dr.GetOrdinal("FechaAlta"))
                            });
                        }
                    }
                }
            }

            return lista;
        }

    }
}