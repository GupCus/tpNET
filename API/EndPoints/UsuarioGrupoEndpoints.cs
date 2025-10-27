using Services;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc; // ✅ AGREGAR ESTE USING

namespace API.EndPoints
{
    public static class UsuarioGrupoEndpoints
    {
        public static void MapUsuarioGrupoEndPoints(this WebApplication app)
        {
            // Agregar relación usuario-grupo
            app.MapPost("/usuario-grupo", ([FromBody] UsuarioGrupoDTO input, [FromServices] UsuarioGrupoService service) =>
            {
                service.Add(input.UsuarioId, input.GrupoId);
                return Results.Created($"/usuario-grupo?usuarioId={input.UsuarioId}&grupoId={input.GrupoId}", input);
            })
            .WithName("CreateUsuarioGrupo")
            .Produces<UsuarioGrupoDTO>(StatusCodes.Status201Created)
            .WithOpenApi();

            // Eliminar relación usuario-grupo
            app.MapDelete("/usuario-grupo", ([FromBody] UsuarioGrupoDTO input, [FromServices] UsuarioGrupoService service) =>
            {
                var ok = service.Delete(input.UsuarioId, input.GrupoId);
                return ok ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteUsuarioGrupo")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            // Obtener grupos de un usuario
            app.MapGet("/usuario-grupo/usuario/{usuarioId:int}", (int usuarioId, [FromServices] UsuarioGrupoService service) =>
            {
                var grupos = service.GetGruposDeUsuario(usuarioId);
                return Results.Ok(grupos);
            })
            .WithName("GetGruposDeUsuario")
            .Produces<IEnumerable<GrupoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            // Obtener usuarios de un grupo
            app.MapGet("/usuario-grupo/grupo/{grupoId:int}", (int grupoId, [FromServices] UsuarioGrupoService service) =>
            {
                var usuarios = service.GetUsuariosDeGrupo(grupoId);
                return Results.Ok(usuarios);
            })
            .WithName("GetUsuariosDeGrupo")
            .Produces<IEnumerable<UsuarioDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}
