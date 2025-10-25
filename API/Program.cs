using API.EndPoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Data;
using DTOs;
using Application.Services;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Swagger / OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Planificador API", Version = "v1" });
            });

            builder.Services.AddHttpLogging(o => { });

            // Usar TPIContext en lugar de PlanificadorContext
            builder.Services.AddDbContext<TPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Registrar repositorios y servicios en DI
            // Ajusta los tipos/namespaces si en tu proyecto difieren.
            builder.Services.AddScoped<CategoriaGastoRepository>();
            builder.Services.AddScoped<CategoriaGastoService>();

            builder.Services.AddScoped<GastoRepository>();
            builder.Services.AddScoped<GastoService>();

            builder.Services.AddScoped<GrupoRepository>();
            builder.Services.AddScoped<GrupoService>();

            builder.Services.AddScoped<PlanRepository>();
            builder.Services.AddScoped<PlanService>();

            builder.Services.AddScoped<TareaRepository>();
            builder.Services.AddScoped<TareaService>();

            builder.Services.AddScoped<UsuarioRepository>();
            builder.Services.AddScoped<UsuarioService>();

            var app = builder.Build();

            // Crear DB si es necesario (development)
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TPIContext>();
                context.Database.EnsureCreated();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHttpLogging();
            }

            app.UseHttpsRedirection();

            // Map endpoints
            app.MapGet("/", () => Results.Redirect("/swagger/"));

            // Llamada corregida al método de mapeo
            app.MapUsuarioEndPoints();
            app.MapCategoriaGastosEndpoints();
            app.MapTareaEndPoints();
            app.MapGastoEndPoints();
            app.MapGrupoEndPoints();
            app.MapPlanEndPoints();

            app.Run();
        }
    }
}