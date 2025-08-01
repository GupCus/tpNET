using Dominio;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapGet("/", () =>
            Results.Redirect("/swagger/"));

            // ==================== CRUD CATEGORIAGASTOS ====================

            //GetALL
            app.MapGet("/categoriagastos/", () =>
            Results.Ok(CategoriaGasto.RepoMemory));

            //GetOne
            app.MapGet("/categoriagastos/{id}", (int id) =>
            CategoriaGasto.RepoMemory.Find(c => c.Id == id) is CategoriaGasto cg
            ? Results.Ok(cg)
            : Results.NotFound(new { message = $"Categoría con ID {id} no encontrada" }));

            //Post
            app.MapPost("/categoriagastos/", (CategoriaGasto cg) =>
            {
                cg.Id = CategoriaGasto.ObtenerProximoId();
                CategoriaGasto.RepoMemory.Add(cg);
                return Results.Created($"/categoriagastos/{cg.Id}", cg);
            });

            //Put
            app.MapPut("/categoriagastos/{id}", (int id, CategoriaGasto cg) =>
            {
                var index = CategoriaGasto.RepoMemory.FindIndex(c => c.Id == id);
                if (index == -1)
                {
                    return Results.NotFound(new { message = $"Categoría con ID {id} no encontrada" });
                }
                else
                {
                    cg.Id = id;
                    CategoriaGasto.RepoMemory[index] = cg;
                    return Results.NoContent();
                }
            });

            //Delete
            app.MapDelete("/categoriagastos/{id}", (int id) =>
            {
                if (CategoriaGasto.RepoMemory.Find(c => c.Id == id) is CategoriaGasto cg)
                {
                    CategoriaGasto.RepoMemory.Remove(cg);
                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound(new { message = $"Categoría con ID {id} no encontrada" });
                }
            });

            // ==================== CRUD TAREAS ====================

            //GetALL
            app.MapGet("/tarea/", () =>
            Results.Ok(Tarea.RepoMemory));

            //GetOne
            app.MapGet("/tarea/{id}", (int id) =>
            Tarea.RepoMemory.Find(t => t.Id == id) is Tarea t
            ? Results.Ok(t)
            : Results.NotFound(new { message = $"Tarea con ID {id} no encontrada" }));

            //Post
            app.MapPost("/tarea/", (Tarea t) =>
            {
                t.Id = Tarea.ObtenerProximoId();
                Tarea.RepoMemory.Add(t);
                return Results.Created($"/tarea/{t.Id}", t);
            });

            //Put
            app.MapPut("/tarea/{id}", (int id, Tarea tarea) =>
            {
                var index = Tarea.RepoMemory.FindIndex(t => t.Id == id);
                if (index == -1)
                {
                    return Results.NotFound(new { message = $"Tarea con ID {id} no encontrada" });
                }
                else
                {
                    tarea.Id = id;
                    Tarea.RepoMemory[index] = tarea;
                    return Results.NoContent();
                }
            });

            //Delete
            app.MapDelete("/tarea/{id}", (int id) =>
            {
                if (Tarea.RepoMemory.Find(t => t.Id == id) is Tarea tarea)
                {
                    Tarea.RepoMemory.Remove(tarea);
                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound(new { message = $"Tarea con ID {id} no encontrada" });
                }
            });

            app.Run();
        }
    }
}
