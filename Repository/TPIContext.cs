using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Dominio;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class TPIContext : DbContext
    {
        public DbSet<CategoriaGasto> CategoriaGastos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public TPIContext(DbContextOptions<TPIContext> options) : base(options)
        {
        }

        public TPIContext()
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

            /* Lo comento porque no me funciona así
            if (!optionsBuilder.IsConfigured)
            {
                // Solo se ejecutará si no se configuró desde Program.cs
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // === CategoriaGasto ===
            modelBuilder.Entity<CategoriaGasto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Tipo).IsRequired().HasMaxLength(150);
                entity.HasIndex(e => e.Tipo).IsUnique();
                entity.Property(e => e.Descripcion).HasMaxLength(500);
            });

            // === Usuario ===
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Mail).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Mail).IsUnique();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Contrasena).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FechaAlta).IsRequired();
                entity.HasData(new
                {
                    Id = 1,
                    Mail = "admin",
                    Nombre = "admin",
                    Contrasena = "admin", 
                    FechaAlta = DateTime.Now
                });
            });

            // === Grupo ===
            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.FechaAlta).IsRequired();
            });

            // === Many-to-many Usuario <-> Grupo ===
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Grupos)
                .WithMany(g => g.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioGrupos",
                    j => j
                        .HasOne<Grupo>()
                        .WithMany()
                        .HasForeignKey("GrupoId")
                        .HasConstraintName("FK_UsuarioGrupo_Grupo")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Usuario>()
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_UsuarioGrupo_Usuario")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("UsuarioId", "GrupoId");
                        j.ToTable("UsuarioGrupos");
                    });

            // === Plan ===
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                v => v.ToDateTime(TimeOnly.MinValue),
                v => DateOnly.FromDateTime(v));
            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.FechaAlta).IsRequired();
                entity.Property(e => e.FechaInicio).HasConversion(dateOnlyConverter).IsRequired();
                entity.Property(e => e.FechaFin).HasConversion(dateOnlyConverter).IsRequired();
            });

            // === Tarea ===
            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.FechaAlta).IsRequired();
            });

            // === Gasto - CONFIGURACIÓN CORREGIDA ===
            modelBuilder.Entity<Gasto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                // ✅ CONFIGURACIÓN SIMPLIFICADA - Elimina las referencias a campos privados
                entity.Property<int>("CategoriaGastoId").IsRequired();
                entity.HasOne(g => g.CategoriaGasto)
                      .WithMany()
                      .HasForeignKey("CategoriaGastoId")
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property<int>("UsuarioId").IsRequired();
                entity.HasOne(g => g.Usuario)
                      .WithMany()
                      .HasForeignKey("UsuarioId")
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Monto).IsRequired();
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.FechaHora).IsRequired();
                entity.Property(e => e.FechaAlta).IsRequired();
            });
        }
    }
}