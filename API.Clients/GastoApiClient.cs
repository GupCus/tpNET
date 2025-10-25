﻿using DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class GastoApiClient
    {
        private static HttpClient client = new HttpClient();

        static GastoApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5183/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<GastoDTO> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"gastos/{id}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<GastoDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener gasto {id}. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<IEnumerable<GastoDTO>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("gastos");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<GastoDTO>>() ?? new List<GastoDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener lista de gastos. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task AddAsync(GastoDTO dto)
        {
            try
            {
                var response = await client.PostAsJsonAsync("gastos", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear gasto. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task UpdateAsync(GastoDTO dto)
        {
            try
            {
                var response = await client.PutAsJsonAsync("gastos", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar gasto Id {dto.Id}. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"gastos/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar gasto Id {id}. Status: {response.StatusCode}, Detalle: {error}");
                }
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }

        public static async Task<IEnumerable<GastoDTO>> GetByCriteriaAsync(string texto)
        {
            try
            {
                var response = await client.GetAsync($"gastos/criteria?texto={Uri.EscapeDataString(texto)}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<IEnumerable<GastoDTO>>() ?? new List<GastoDTO>();
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en búsqueda. Status: {response.StatusCode}, Detalle: {error}");
            }
            catch (HttpRequestException ex) { throw new Exception($"Error de conexión: {ex.Message}", ex); }
            catch (TaskCanceledException ex) { throw new Exception($"Timeout: {ex.Message}", ex); }
        }
    }
}
