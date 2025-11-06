using DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace API.Clients
{
    public class UsuarioGrupoApiClient
    {
        private static HttpClient client = new HttpClient();

        static UsuarioGrupoApiClient()
        {
            client.BaseAddress = new Uri("https://localhost:5183/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task AddAsync(UsuarioGrupoDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("usuario-grupo", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear relación usuario-grupo. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task DeleteAsync(UsuarioGrupoDTO dto)
        {
            try
            {
                
                var request = new HttpRequestMessage(HttpMethod.Delete, "usuario-grupo")
                {
                    Content = JsonContent.Create(dto)
                };
                var response = await client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar relación usuario-grupo. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<IEnumerable<GrupoDTO>> GetGruposDeUsuarioAsync(int usuarioId)
        {
            try
            {
                
                var response = await client.GetAsync($"usuario-grupo/usuario/{usuarioId}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<GrupoDTO>>() ?? new List<GrupoDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener grupos del usuario. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<IEnumerable<UsuarioDTO>> GetUsuariosDeGrupoAsync(int grupoId)
        {
            try
            {
                var response = await client.GetAsync($"usuario-grupo/grupo/{grupoId}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<UsuarioDTO>>() ?? new List<UsuarioDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener usuarios del grupo. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }
    }
}