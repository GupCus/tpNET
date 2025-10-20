using Services;
using Dominio;
using System.Diagnostics.Eventing.Reader;
using DTOs;
namespace API.EndPoints
{
    public static class UsuarioEndPoints
    { public static void MapUsuarioEndPoints(this WebApplication app)
        {
            app.MapGet("/usuario/", async (UsuarioService usuarioService) =>
            {
                var users = await usuarioService.GetAll();

                return Results.Ok(users);
            });
            app.MapGet("/usuario/{id}", async (int id, UsuarioService usuarioService) =>
            {

                var user = await usuarioService.GetOneAsync(id);
                if (user == null) { return Results.NotFound(new  { message = $"Usuario con id {id} no se encuentra" }); }
                else { return Results.Ok(user); }
            });

            app.MapPost("/usuario", async (UsuarioDTO user , UsuarioService usuarioService) => {
                var u = await usuarioService.Add(user);
                return Results.Created($"usuario/{u.Id}", u);
            });

            app.MapPut("/usuario/{id}", async (int id, UsuarioUpdateDTO dto, UsuarioService usuarioService) =>
            {
                dto.Id = id;
                bool actualizado = await usuarioService.Update(dto);
                if (actualizado == false)
                {
                    return Results.NotFound(new { message = $"Usuario con ID {id} no encontrado" });

                }
                else
                {
                    return Results.NoContent();
                }
            });
            app.MapDelete("/usuario/{id}", async (int id,UsuarioService usuarioService) =>
            {
                bool eliminado = await usuarioService.Delete(id);
                if (!eliminado)
                {
                    return Results.NotFound(new { message = $"couldnt delete user with ID {id}"
                    });

                }
                else return Results.NoContent();

            });
    }
    } }
