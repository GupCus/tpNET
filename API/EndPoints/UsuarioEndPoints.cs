using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace API.EndPoints
{
    public static class UsuarioEndpoints
    {
        // Nombre corregido: MapUsuarioEndPoints (antes había un typo)
        public static void MapUsuarioEndPoints(this WebApplication app)
        {
            app.MapGet("/usuarios", (UsuarioService service) =>
            {
                var dtos = service.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllUsuarios")
            .Produces<IEnumerable<UsuarioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapGet("/usuarios/{id:int}", (int id, UsuarioService service) =>
            {
                var dto = service.Get(id);
                return dto == null ? Results.NotFound() : Results.Ok(dto);
            })
            .WithName("GetUsuarioById")
            .Produces<UsuarioDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapPost("/usuarios", (UsuarioUpdateDTO input, UsuarioService service) =>
            {
                var created = service.Add(input);
                return Results.Created($"/usuarios/{created.Id}", created);
            })
            .WithName("CreateUsuario")
            .Produces<UsuarioDTO>(StatusCodes.Status201Created)
            .WithOpenApi();

            app.MapPut("/usuarios", (UsuarioUpdateDTO input, UsuarioService service) =>
            {
                var ok = service.Update(input);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapDelete("/usuarios/{id:int}", (int id, UsuarioService service) =>
            {
                var ok = service.Delete(id);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteUsuario")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/usuarios/criteria", (string texto, UsuarioService service) =>
            {
                var items = service.GetByCriteria(new UsuarioCriteriaDTO { Texto = texto });
                return Results.Ok(items);
            })
            .WithName("GetUsuariosByCriteria")
            .Produces<IEnumerable<UsuarioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}
