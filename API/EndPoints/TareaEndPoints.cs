using Services;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace API.EndPoints
{
    public static class TareaEndpoints
    {
        public static void MapTareaEndPoints(this WebApplication app)
        {
            app.MapGet("/tareas", (TareaService service) =>
            {
                var dtos = service.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllTareas")
            .Produces<IEnumerable<TareaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/tareas/{id:int}", (int id, TareaService service) =>
            {
                var dto = service.Get(id);
                return dto == null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("GetTareaById")
            .Produces<TareaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPost("/tareas", (TareaDTO input, TareaService service) =>
            {
                var created = service.Add(input);
                return Results.Created($"/tareas/{created.Id}", created);
            })
            .WithName("CreateTarea")
            .Produces<TareaDTO>(StatusCodes.Status201Created)
            .WithOpenApi();

            app.MapPut("/tareas", (TareaDTO input, TareaService service) =>
            {
                var ok = service.Update(input);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateTarea")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapDelete("/tareas/{id:int}", (int id, TareaService service) =>
            {
                var ok = service.Delete(id);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteTarea")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/tareas/criteria", (string texto, TareaService service) =>
            {
                var items = service.GetByCriteria(new TareaCriteriaDTO { Texto = texto });
                return Results.Ok(items);
            })
            .WithName("GetTareasByCriteria")
            .Produces<IEnumerable<TareaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}