using System.Reflection.Metadata.Ecma335;
using Dominio;
using Repository;

namespace API.EndPoints
{
    public static class GrupoEndpoint
    {
        public static void MapGrupoEndPoints(this WebApplication app)
        {
            app.MapGet("/grupo/", async () =>
            {
                Results.Ok(await GrupoRepository.GetAll());
            });
            app.MapGet("/grupo/{id}", async (int id) =>
                await GrupoRepository.GetOne(id) is Grupo g ?
                Results.Ok(g) :
                Results.NotFound(new
                {
                    message = $"Grupo con {id} no se encuentra "
                })
            );

            app.MapPost("/grupo/", async (Grupo g) =>
            {
                var grupo = await GrupoRepository.Post(g);
                Results.Created($"/grupo/{grupo.Id}", grupo);
            });
           app.MapPut("/grupo/{id}", async (int id, Grupo g) =>
                {
                    g.Id = id;

                    var grupo = await GrupoRepository.Put(g);
                    if (grupo != null)
                    {
                        return Results.NoContent();
                    }
                    else
                    {
                        return Results.NotFound(new { message = $"grupo con {id} no se encuentra" });
                    }
                });
                app.MapDelete("/grupo/{id}", async (int id) =>
                {
                    if (await GrupoRepository.Delete(id) == null)
                    {
                        return Results.NotFound(new { message = $"grupo con {id} no se encuentra" });
                    }
                    else
                    {
                        return Results.NoContent();
                    }
                });

            }
        }
    }

