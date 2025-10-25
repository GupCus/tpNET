using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<CategoriaGasto> CategoriaGastos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        internal TPIContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
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
                entity.Property(e => e.FechaAlta).IsRequired();
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

                // indicar que la navegación Grupos usa backing field "_grupos"
                var nav = entity.Metadata.FindNavigation(nameof(Usuario.Grupos));
                if (nav != null)
                    nav.SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            // === Grupo ===
            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.FechaAlta).IsRequired();

                // Map backing fields for collections
                entity.Navigation(nameof(Grupo.Usuarios)).HasField("_usuarios");
                entity.Navigation(nameof(Grupo.Planes)).HasField("_planes");
            });

            // === Many-to-many Usuario <-> Grupo (tabla intermedia explícita) ===
            modelBuilder.Entity<Usuario>()
                .HasMany(typeof(Grupo), "_grupos")
                .WithMany("_usuarios")
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioGrupo",
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
            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.FechaAlta).IsRequired();

                // DateOnly -> DateTime conversion
                var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                    v => v.ToDateTime(TimeOnly.MinValue),
                    v => DateOnly.FromDateTime(v));
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

                // Gastos collection backing field
                entity.Navigation(nameof(Tarea.Gastos)).HasField("_gastos");
            });

            // === Gasto ===
            modelBuilder.Entity<Gasto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                // Categoria relationship (backing field + shadow FK column)
                entity.Property<int>("_categoriaGastoId").HasColumnName("CategoriaGastoId").IsRequired();
                entity.Navigation(nameof(Gasto.CategoriaGasto)).HasField("_categoriaGasto");
                entity.HasOne(g => g.CategoriaGasto)
                      .WithMany()
                      .HasForeignKey("CategoriaGastoId")
                      .OnDelete(DeleteBehavior.Restrict);

                // Usuario relationship
                entity.Property<int>("_usuarioId").HasColumnName("UsuarioId").IsRequired();
                entity.Navigation(nameof(Gasto.Usuario)).HasField("_usuario");
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