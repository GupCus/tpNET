using Dominio;
using Repository;

namespace API.EndPoints
{
    public static class TareaEndPoints
    {
        public static void MapTareaEndPoints(this WebApplication app)
        {
            // ==================== CRUD TAREAS ====================

            //GetALL
            app.MapGet("/tarea/", async () =>
            Results.Ok(await TareaRepository.GetAll()));

            //GetOne
            app.MapGet("/tarea/{id}", async (int id) =>
            await TareaRepository.GetOne(id) is Tarea t
            ? Results.Ok(t)
            : Results.NotFound(new { message = $"Tarea con ID {id} no encontrada" }));


            //Post
            app.MapPost("/tarea/", async (Tarea t) =>
            {
                var nt = await TareaRepository.Post(t);
                return Results.Created($"/tarea/{nt.Id}", nt);
            });

            //Put
            app.MapPut("/tarea/{id}", async (int id, Tarea t) =>
            {
                t.Id = id;
                var mt = await TareaRepository.Put(t);
                if (mt == null)
                {
                    return Results.NotFound(new { message = $"Tarea con ID {id} no encontrada" });
                }
                else
                {
                    return Results.NoContent();
                }
            });

            //Delete
            app.MapDelete("/tarea/{id}", async (int id) =>
            {
                if (await TareaRepository.Delete(id) == null)
                {
                    return Results.NotFound(new { message = $"Tarea con ID {id} no encontrada" });
                }
                else
                {
                    return Results.NoContent();
                }
            });
        }
    }
}
