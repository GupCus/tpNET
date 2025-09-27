using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Dominio;

namespace Repository
{
    public class PlanificadorContext : DbContext
    {
        public DbSet<CategoriaGasto> CategoriaGastos { get; set; }
        public DbSet<Tarea> Tarea { get; set; }

        public DbSet<Gasto> Gasto { get; set; }

        internal PlanificadorContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;
                                        Initial Catalog=Planificador;
                                        Integrated Security=true;
                                        TrustServerCertificate=True");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

    }
}
