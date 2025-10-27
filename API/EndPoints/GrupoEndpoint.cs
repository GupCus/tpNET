using Services;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace API.EndPoints
{
    public static class GrupoEndPoints
    {
        public static void MapGrupoEndPoints(this WebApplication app)
        {
            app.MapGet("/grupos", (GrupoService service) =>
            {
                var dtos = service.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllGrupos")
            .Produces<IEnumerable<GrupoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/grupos/{id:int}", (int id, GrupoService service) =>
            {
                var dto = service.Get(id);
                return dto == null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("GetGrupoById")
            .Produces<GrupoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPost("/grupos", (GrupoDTO input, GrupoService service) =>
            {
                var created = service.Add(input);
                return Results.Created($"/grupos/{created.Id}", created);
            })
            .WithName("CreateGrupo")
            .Produces<GrupoDTO>(StatusCodes.Status201Created)
            .WithOpenApi();

            app.MapPut("/grupos", (GrupoDTO input, GrupoService service) =>
            {
                var ok = service.Update(input);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateGrupo")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapDelete("/grupos/{id:int}", (int id, GrupoService service) =>
            {
                var ok = service.Delete(id);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteGrupo")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/grupos/criteria", (string texto, GrupoService service) =>
            {
                var items = service.GetByCriteria(new GrupoCriteriaDTO { Texto = texto });
                return Results.Ok(items);
            })
            .WithName("GetGruposByCriteria")
            .Produces<IEnumerable<GrupoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/grupos/byadmin/{idAdministrador:int}", (int idAdministrador, GrupoService service) =>
            {
                var grupos = service.GetByAdministrador(idAdministrador);
                return Results.Ok(grupos);
            });

        }
    }
}