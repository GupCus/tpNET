using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using Dominio;
using System.Net.Http.Headers;
using System.Net.Http.Json;
namespace API.Clients
{
    public class CategoriaGastoApiClient
    {
        private static HttpClient client = new HttpClient();

        static CategoriaGastoApiClient()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
        (sender, cert, chain, sslPolicyErrors) => true;

            client.BaseAddress = new Uri("https://localhost:5183/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task AddAsync(CategoriaGastoDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("categoriagastos", dto );
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear categoria. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }
        

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"categoriagastos/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar categoria con Id {id}. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<CategoriaGastoDTO> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"categoriagastos/{id}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<CategoriaGastoDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener categoria con ID {id}. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }
        

        public static async Task<IEnumerable<CategoriaGastoDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("categoriagastos");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<CategoriaGastoDTO>>() ?? new List<CategoriaGastoDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener lista de categorias. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) {  throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task UpdateAsync(CategoriaGastoUpdateDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("categoriagastos", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar categoria con Id {dto.Id}. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        /*public IEnumerable<CategoriaGasto> GetByCriteria(UsuarioCriteriaDTO criteriaDTO)
        {
            var repo = new CategoriaGastoRepository();
            var items = repo.GetByCriteria(criteriaDTO.Texto);
            return items.Select(u => new CategoriaGasto
            {
                Id = u.Id,
                Tipo = u.Tipo,
                Descripcion = u.Descripcion,
                
            });
        }*/
    }
}