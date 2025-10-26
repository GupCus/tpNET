using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class GrupoApiClient
    {
        private static HttpClient client = new HttpClient();

        static GrupoApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5032/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<GrupoDTO> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"grupos/{id}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<GrupoDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener grupo {id}. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<IEnumerable<GrupoDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("grupos");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<GrupoDTO>>() ?? new List<GrupoDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener lista de grupos. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task AddAsync(GrupoDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("grupos", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear grupo. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task UpdateAsync(GrupoDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("grupos", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar grupo Id {dto.Id}. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"grupos/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar grupo Id {id}. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<IEnumerable<GrupoDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                var response = await client.GetAsync($"grupos/criteria?texto={Uri.EscapeDataString(texto)}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<GrupoDTO>>() ?? new List<GrupoDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en búsqueda. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }
    }
}
