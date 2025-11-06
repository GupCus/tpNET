using Microsoft.EntityFrameworkCore;
using Dominio;

namespace Repository
{
    public class GrupoRepository
    {
        private TPIContext CreateContext() => new TPIContext();

        public void Add(Grupo grupo)
        {
            using var ctx = CreateContext();
            ctx.Grupos.Add(grupo);
            ctx.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var ctx = CreateContext();
            var g = ctx.Grupos.Find(id);
            if (g == null) return false;
            ctx.Grupos.Remove(g);
            ctx.SaveChanges();
            return true;
        }

        public Grupo? Get(int id)
        {
            using var ctx = CreateContext();
            return ctx.Grupos
                      .Include(g => g.GrupoUsuarios)
                        .ThenInclude(gu => gu.Usuario)
                      .Include(g => g.Planes)
                      .FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Grupo> GetAll()
        {
            using var ctx = CreateContext();
            return ctx.Grupos
                        .Include(g => g.GrupoUsuarios)
                          .ThenInclude(gu => gu.Usuario)
                        .Include(g => g.Planes)
                        .ToList();
        }

        public bool Update(Grupo grupo)
        {
            using var ctx = CreateContext();
            var existing = ctx.Grupos
                              .Include(g => g.GrupoUsuarios)
                              .FirstOrDefault(g => g.Id == grupo.Id);
            if (existing == null) return false;
            existing.SetNombre(grupo.Nombre);
            existing.SetDescripcion(grupo.Descripcion);
            existing.SetFechaAlta(grupo.FechaAlta);
            existing.SetIdUsuarioAdministrador(grupo.IdUsuarioAdministrador);
            ctx.SaveChanges();
            return true;
        }

        public bool NameExists(string nombre, int? excludeId = null)
        {
            using var ctx = CreateContext();
            var q = ctx.Grupos.Where(g => g.Nombre.ToLower() == nombre.ToLower());
            if (excludeId.HasValue) q = q.Where(g => g.Id != excludeId.Value);
            return q.Any();
        }

        public IEnumerable<Grupo> GetByCriteria(string texto)
        {
            using var ctx = CreateContext();
            if (string.IsNullOrWhiteSpace(texto)) return ctx.Grupos.ToList();
            texto = texto.ToLower();
            return ctx.Grupos.Where(g => g.Nombre.ToLower().Contains(texto) || (g.Descripcion != null && g.Descripcion.ToLower().Contains(texto))).ToList();
        }
    }
}
