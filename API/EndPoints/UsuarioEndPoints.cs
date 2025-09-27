using Repository;
using Dominio;
using System.Diagnostics.Eventing.Reader;
namespace API.EndPoints
{
    public static class UsuarioEndPoints
    { public static void MapUsuarioEndPoints(this WebApplication app)
        {
            app.MapGet("/usuario/", async () =>
            {
                var users = await UsuarioRepository.GetAll();
                Console.WriteLine($"Usuarios en DB: {users?.Length}");
                return Results.Ok(users);
            });
            app.MapGet("/usuario/{id}", async (int id) =>

                await UsuarioRepository.GetOne(id) is Usuario user ?
                Results.Ok(user) :
                Results.NotFound(new { message = $"user with ID {id} not found" }));


            app.MapPost("/usuario", async (Usuario user) => {
                var u = await UsuarioRepository.Add(user);
                return Results.Created($"usuario/{u.Id}", u);
            });

            app.MapPut("/usuario/{id}", async (int id, Usuario user) =>
            {
                user.Id = id;
                var u = await UsuarioRepository.Update(user);
                if (u == null)
                {
                    return Results.NotFound(new { message = $"Usuario con ID {id} no encontrado" });

                }
                else
                {
                    return Results.NoContent();
                }
            });
            app.MapDelete("/usuario/{id}", async (int id) =>
            {
                if (await UsuarioRepository.Delete(id) == null)
                {
                    return Results.NotFound(new { message = $"couldnt delete user with ID {id}"
                    });

                }
                else return Results.NoContent();

            });
    }
    } }
