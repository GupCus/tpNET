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
            app.MapGet("api/reportes/gastos-grupo/{grupoId:int}", (int grupoId, GastoService gastoService) =>
            {
                var reporte = gastoService.GetReporteByGrupoId(grupoId);
                return Results.Ok(reporte);
            })
            .WithName("GetReporteByGrupo")
            .Produces<IEnumerable<GastoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();
        }
    }
}