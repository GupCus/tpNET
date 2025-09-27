using Dominio;
using Repository;

namespace API.EndPoints
{
    public static class GastoEndPoints
    {
        public static void MapGastoEndPoints(this WebApplication app)
        {
            // ==================== CRUD GASTOS ====================

            //GetALL
            app.MapGet("/gasto/", async () =>
            Results.Ok(await GastoRepository.GetAll()));

            //GetOne
            app.MapGet("/gasto/{id}", async (int id) =>
            await GastoRepository.GetOne(id) is Gasto g
            ? Results.Ok(g)
            : Results.NotFound(new { message = $"Gasto con ID {id} no encontrado" }));

            //Post
            app.MapPost("/gasto/", async (Gasto g) =>
            {
                var ng = await GastoRepository.Post(g);
                return Results.Created($"/gasto/{ng.Id}", ng);
            });

            //Put
            app.MapPut("/gasto/{id}", async (int id, Gasto g) =>
            {
                g.Id = id;
                var mg = await GastoRepository.Put(g);
                if (mg == null)
                {
                    return Results.NotFound(new { message = $"Gasto con ID {id} no encontrado" });
                }
                else
                {
                    return Results.NoContent();
                }
            });

            //Delete
            app.MapDelete("/gasto/{id}", async (int id) =>
            {
                if (await GastoRepository.Delete(id) == null)
                {
                    return Results.NotFound(new { message = $"Gasto con ID {id} no encontrado" });
                }
                else
                {
                    return Results.NoContent();
                }
            });
        }
    }
}