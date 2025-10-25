using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace API.EndPoints
{
    public static class CategoriaGastoEndpoints
    {
        public static void MapCategoriaGastosEndpoints(this WebApplication app)
        {
            app.MapGet("/categoriagastos", (CategoriaGastoService service) =>
            {
                var dtos = service.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllCategoriaGastos")
            .Produces<IEnumerable<CategoriaGastoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/categoriagastos/{id:int}", (int id, CategoriaGastoService service) =>
            {
                var dto = service.Get(id);
                return dto == null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("GetCategoriaGastoById")
            .Produces<CategoriaGastoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPost("/categoriagastos", (CategoriaGastoDTO input, CategoriaGastoService service) =>
            {
                var created = service.Add(input);
                return Results.Created($"/categoriagastos/{created.Id}", created);
            })
            .WithName("CreateCategoriaGasto")
            .Produces<CategoriaGastoDTO>(StatusCodes.Status201Created)
            .WithOpenApi();

            app.MapPut("/categoriagastos", (CategoriaGastoDTO input, CategoriaGastoService service) =>
            {
                var ok = service.Update(input);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateCategoriaGasto")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapDelete("/categoriagastos/{id:int}", (int id, CategoriaGastoService service) =>
            {
                var ok = service.Delete(id);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteCategoriaGasto")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/categoriagastos/criteria", (string texto, CategoriaGastoService service) =>
            {
                var items = service.GetByCriteria(new CategoriaGastoCriteriaDTO { Texto = texto });
                return Results.Ok(items);
            })
            .WithName("GetCategoriaGastosByCriteria")
            .Produces<IEnumerable<CategoriaGastoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}
