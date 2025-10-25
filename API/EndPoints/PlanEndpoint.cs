using Services;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace API.EndPoints
{
    public static class PlanEndpoint
    {
        public static void MapPlanEndPoints(this WebApplication app)
        {
            app.MapGet("/planes", (PlanService service) =>
            {
                var dtos = service.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllPlanes")
            .Produces<IEnumerable<PlanDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/planes/{id:int}", (int id, PlanService service) =>
            {
                var dto = service.Get(id);
                return dto == null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("GetPlanById")
            .Produces<PlanDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPost("/planes", (PlanDTO input, PlanService service) =>
            {
                var created = service.Add(input);
                return Results.Created($"/planes/{created.Id}", created);
            })
            .WithName("CreatePlan")
            .Produces<PlanDTO>(StatusCodes.Status201Created)
            .WithOpenApi();

            app.MapPut("/planes", (PlanDTO input, PlanService service) =>
            {
                var ok = service.Update(input);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdatePlan")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapDelete("/planes/{id:int}", (int id, PlanService service) =>
            {
                var ok = service.Delete(id);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeletePlan")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/planes/criteria", (string texto, PlanService service) =>
            {
                var items = service.GetByCriteria(new PlanCriteriaDTO { Texto = texto });
                return Results.Ok(items);
            })
            .WithName("GetPlanesByCriteria")
            .Produces<IEnumerable<PlanDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}