using Domain.Model;

namespace Data
{
    public class CategoriaGastoRepository
    {
        private TPIContext CreateContext() => new TPIContext();

        public void Add(CategoriaGasto entity)
        {
            using var ctx = CreateContext();
            ctx.CategoriaGastos.Add(entity);
            ctx.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var ctx = CreateContext();
            var e = ctx.CategoriaGastos.Find(id);
            if (e == null) return false;
            ctx.CategoriaGastos.Remove(e);
            ctx.SaveChanges();
            return true;
        }

        public CategoriaGasto? Get(int id)
        {
            using var ctx = CreateContext();
            return ctx.CategoriaGastos.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CategoriaGasto> GetAll()
        {
            using var ctx = CreateContext();
            return ctx.CategoriaGastos.ToList();
        }

        public bool Update(CategoriaGasto entity)
        {
            using var ctx = CreateContext();
            var existing = ctx.CategoriaGastos.Find(entity.Id);
            if (existing == null) return false;
            existing.SetTipo(entity.Tipo);
            existing.SetDescripcion(entity.Descripcion);
            existing.SetFechaAlta(entity.FechaAlta);
            ctx.SaveChanges();
            return true;
        }

        public bool NameExists(string tipo, int? excludeId = null)
        {
            using var ctx = CreateContext();
            var q = ctx.CategoriaGastos.Where(c => c.Tipo.ToLower() == tipo.ToLower());
            if (excludeId.HasValue) q = q.Where(c => c.Id != excludeId.Value);
            return q.Any();
        }

        public IEnumerable<CategoriaGasto> GetByCriteria(string texto)
        {
            using var ctx = CreateContext();
            if (string.IsNullOrWhiteSpace(texto)) return ctx.CategoriaGastos.ToList();
            texto = texto.ToLower();
            return ctx.CategoriaGastos.Where(c => c.Tipo.ToLower().Contains(texto) || (c.Descripcion != null && c.Descripcion.ToLower().Contains(texto))).ToList();
        }
    }
}
