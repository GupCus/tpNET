using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dominio;
using Microsoft.Extensions.Logging;
using System;
using Dominio.Dominio;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
        public DbSet<UsuarioGrupo> GrupoUsuarios { get; set; }

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
                    FechaAlta = new DateTime(2025, 10, 27),
                    Rol = "Admin"
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

            // === Many-to-many Usuario <-> Grupo usando GrupoUsuario ===
            modelBuilder.Entity<UsuarioGrupo>(entity =>
            {
                entity.HasKey(e => new { e.GrupoId, e.UsuarioId });
                entity.Property(e => e.FechaAlta).IsRequired();

                entity.HasOne(e => e.Grupo)
                    .WithMany(g => g.GrupoUsuarios)
                    .HasForeignKey(e => e.GrupoId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.GrupoUsuarios)
                    .HasForeignKey(e => e.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.ToTable("GrupoUsuarios");
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
                entity.Property(e => e.FechaAlta).HasConversion(dateOnlyConverter).IsRequired();
                entity.Property(e => e.FechaInicio).HasConversion(dateOnlyConverter).IsRequired();
                entity.Property(e => e.FechaFin).HasConversion(dateOnlyConverter).IsRequired();

                // ✅ CONFIGURACIÓN CORREGIDA - Usar propiedad real
                entity.Property(e => e.GrupoId).IsRequired();
                entity.HasOne(p => p.Grupo)
                      .WithMany(g => g.Planes)
                      .HasForeignKey(e => e.GrupoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // === Tarea ===
            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.FechaAlta).IsRequired();

                // ✅ CONFIGURACIÓN CORREGIDA - Usar propiedad real
                entity.Property(e => e.PlanId).IsRequired();
                entity.HasOne(t => t.Plan)
                      .WithMany()
                      .HasForeignKey(e => e.PlanId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // === Gasto ===
            modelBuilder.Entity<Gasto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CategoriaGastoId).IsRequired();
                entity.HasOne(g => g.CategoriaGasto)
                      .WithMany()
                      .HasForeignKey(e => e.CategoriaGastoId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.UsuarioId).IsRequired();
                entity.HasOne(g => g.Usuario)
                      .WithMany()
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Monto).IsRequired();
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.FechaHora).IsRequired();
                entity.Property(e => e.FechaAlta).IsRequired();
            });
        }
    }
}