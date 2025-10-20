using API.EndPoints;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;
namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpLogging(o => { });
            builder.Services.AddDbContext<PlanificadorContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

            
            builder.Services.AddScoped<UsuarioRepository>();
            builder.Services.AddScoped<UsuarioService>();
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<PlanificadorContext>();
                context.Database.EnsureCreated();
            }


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHttpLogging();
            }

            app.UseHttpsRedirection();

            //Map endpoints

            app.MapGet("/", () => Results.Redirect("/swagger/"));
            app.MapUsuarioEndPoints();
            app.MapCategoriaGastosEndpoints();
            app.MapTareaEndPoints();
            app.MapGastoEndPoints();
            app.MapGrupoEndPoints();
            app.Run();
        }
    }
}
