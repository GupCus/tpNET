using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class TareaApiClient
    {
        private static HttpClient client = new HttpClient();

        static TareaApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5183/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<TareaDTO> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"tareas/{id}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<TareaDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener tarea {id}. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<IEnumerable<TareaDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("tareas");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<TareaDTO>>() ?? new List<TareaDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener lista de tareas. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task AddAsync(TareaDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("tareas", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear tarea. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task UpdateAsync(TareaDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("tareas", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar tarea Id {dto.Id}. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"tareas/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar tarea Id {id}. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<IEnumerable<TareaDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                var response = await client.GetAsync($"tareas/criteria?texto={Uri.EscapeDataString(texto)}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<TareaDTO>>() ?? new List<TareaDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en búsqueda. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }
    }
}
