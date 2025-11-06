using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Services;
using DTOs;
using System.Collections.Generic;

namespace API.EndPoints
{
    public static class ReporteEndpoints
    {
        public static void MapReporteEndpoints(this WebApplication app)
        {
            // Devuelve todos los gastos de todas las tareas de todos los planes de un grupo
            app.MapGet("/api/reportes/gastos-grupo/{grupoId:int}", (int grupoId, GastoService gastoService) =>
            {
                var items = gastoService.GetByGrupoId(grupoId);
                return Results.Ok(items);
            })
            .WithName("GetGastosByGrupo")
            .Produces<IEnumerable<GastoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}