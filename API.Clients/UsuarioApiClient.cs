using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class UsuarioApiClient
    {
        private static HttpClient client = new HttpClient();

        static UsuarioApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5183/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<UsuarioDTO> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"usuarios/{id}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener usuario {id}. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("usuarios");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<UsuarioDTO>>() ?? new List<UsuarioDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener lista de usuarios. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<UsuarioDTO> AddAsync(UsuarioUpdateDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("usuarios", dto);
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear usuario. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task UpdateAsync(UsuarioUpdateDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("usuarios", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar usuario Id {dto.Id}. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"usuarios/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar usuario Id {id}. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<IEnumerable<UsuarioDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                var response = await client.GetAsync($"usuarios/criteria?texto={Uri.EscapeDataString(texto)}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<UsuarioDTO>>() ?? new List<UsuarioDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en búsqueda. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }
    }
}