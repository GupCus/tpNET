using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Dominio;

namespace Repository
{
    public class PlanificadorContext : DbContext
    {
        public DbSet<CategoriaGasto> CategoriaGastos { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Gasto> Gasto { get; set; }
        public DbSet<Grupo> Grupo { get;set; }

        public PlanificadorContext(DbContextOptions<PlanificadorContext> options)
       : base(options)
        {
            
        }

        public PlanificadorContext()
        {
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;
                                        Initial Catalog=Planificador;
                                        Integrated Security=true;
                                        TrustServerCertificate=True");
                optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            }
        }

    }
}
