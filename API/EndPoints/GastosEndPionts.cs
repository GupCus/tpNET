using Services;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace API.EndPoints
{
    public static class GastoEndpoints
    {
        public static void MapGastoEndPoints(this WebApplication app)
        {
            app.MapGet("/gastos", (GastoService service) =>
            {
                var dtos = service.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllGastos")
            .Produces<IEnumerable<GastoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/gastos/{id:int}", (int id, GastoService service) =>
            {
                var dto = service.Get(id);
                return dto == null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("GetGastoById")
            .Produces<GastoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPost("/gastos", (GastoDTO input, GastoService service) =>
            {
                var created = service.Add(input);
                return Results.Created($"/gastos/{created.Id}", created);
            })
            .WithName("CreateGasto")
            .Produces<GastoDTO>(StatusCodes.Status201Created)
            .WithOpenApi();

            app.MapPut("/gastos", (GastoDTO input, GastoService service) =>
            {
                var ok = service.Update(input);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateGasto")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapDelete("/gastos/{id:int}", (int id, GastoService service) =>
            {
                var ok = service.Delete(id);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteGasto")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/gastos/criteria", (string texto, GastoService service) =>
            {
                var items = service.GetByCriteria(new GastoCriteriaDTO { Texto = texto });
                return Results.Ok(items);
            })
            .WithName("GetGastosByCriteria")
            .Produces<IEnumerable<GastoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}