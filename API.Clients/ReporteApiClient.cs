using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class ReporteApiClient
    {
        private static HttpClient client;

        static ReporteApiClient()
        {
            client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            });
            client.BaseAddress = new Uri("https://localhost:5183/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<ReporteGastosGrupoDto> GetReporteGastosGrupoAsync(int grupoId)
        {
            try
            {
                var response = await client.GetAsync($"api/reportes/gastos-grupo/{grupoId}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<ReporteGastosGrupoDto>();

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener reporte de gastos del grupo {grupoId}. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<IEnumerable<GrupoDTO>> GetGruposAsync()
        {
            try
            {
                var response = await client.GetAsync("api/reportes/grupos");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<GrupoDTO>>() ?? new List<GrupoDTO>();

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener lista de grupos. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<IEnumerable<GrupoDTO>> GetGruposPorUsuarioAsync(int usuarioId)
        {
            try
            {
                var response = await client.GetAsync($"api/reportes/grupos/usuario/{usuarioId}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<GrupoDTO>>() ?? new List<GrupoDTO>();

                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener grupos del usuario {usuarioId}. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }
    }
}