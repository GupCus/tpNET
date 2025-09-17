using Dominio;

namespace API.EndPoints
{
    public static class TareaEndPoints
    {
        public static void MapTareaEndPoints(this WebApplication app)
        {
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
        }
    }
}
