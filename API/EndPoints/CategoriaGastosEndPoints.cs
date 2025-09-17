using Dominio;
using Repository;
namespace API.EndPoints
{
    public static class CategoriaGastosEndPoints
    {
        public static void MapCategoriaGastosEndpoints(this WebApplication app)
        {
            // ==================== CRUD CATEGORIAGASTOS ====================

            //GetALL
            app.MapGet("/categoriagastos/", async () =>
            Results.Ok(await CategoriaGastosRepository.GetAll()));

            //GetOne
            app.MapGet("/categoriagastos/{id}", async (int id) =>
            await CategoriaGastosRepository.GetOne(id) is CategoriaGasto cg
            ? Results.Ok(cg)
            : Results.NotFound(new { message = $"Categoría con ID {id} no encontrada" }));

            //Post
            app.MapPost("/categoriagastos/", async (CategoriaGasto cg) =>
            {
                var ncg = await CategoriaGastosRepository.Post(cg);
                return Results.Created($"/categoriagastos/{ncg.Id}", ncg);
            });

            //Put
            app.MapPut("/categoriagastos/{id}", async (int id, CategoriaGasto cg) =>
            {
                cg.Id = id;
                var mcg = await CategoriaGastosRepository.Put(cg);
                if (mcg == null)
                {
                    return Results.NotFound(new { message = $"Categoría con ID {id} no encontrada" });
                }
                else
                {
                    return Results.NoContent();
                }
            });


            //Delete
            app.MapDelete("/categoriagastos/{id}", async (int id) =>
            {
                if (await CategoriaGastosRepository.Delete(id) == null)
                {
                    return Results.NotFound(new { message = $"Categoría con ID {id} no encontrada" }); 
                }
                else
                {
                    return Results.NoContent();
                }
            });
        }
    }
}
