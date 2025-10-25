
using Microsoft.EntityFrameworkCore;
using Dominio;

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
    }
}