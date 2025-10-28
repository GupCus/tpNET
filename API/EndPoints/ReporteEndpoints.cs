using Microsoft.AspNetCore.Mvc;
using Services;
using DTOs;

namespace API.EndPoints
{
    public static class ReporteEndpoints
    {
        public static void MapReporteEndpoints(this WebApplication app)
        {
            app.MapGet("/api/reportes/gastos-grupo/{grupoId}", async (int grupoId) =>
            {
                try
                {
                    var reporteService = new ReporteService();
                    var reporte = await reporteService.ObtenerReporteGastosPorGrupo(grupoId);
                    return Results.Ok(reporte);
                }
                catch (ArgumentException ex)
                {
                    return Results.NotFound(new { error = ex.Message });
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error al generar reporte: {ex.Message}");
                }
            });

            // Endpoint para obtener grupos (usando tu GrupoService existente)
            app.MapGet("/api/reportes/grupos", async () =>
            {
                try
                {
                    var grupoService = new GrupoService();
                    var grupos = grupoService.GetAll(); // Usa tu método existente
                    return Results.Ok(grupos);
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error al obtener grupos: {ex.Message}");
                }
            });

            // Endpoint adicional para obtener grupos del usuario actual
            app.MapGet("/api/reportes/grupos/usuario/{usuarioId}", async (int usuarioId) =>
            {
                try
                {
                    var grupoService = new GrupoService();
                    var grupos = grupoService.GetByUsuario(usuarioId); // Usa tu método existente
                    return Results.Ok(grupos);
                }
                catch (Exception ex)
                {
                    return Results.Problem($"Error al obtener grupos del usuario: {ex.Message}");
                }
            });
        }
    }
}