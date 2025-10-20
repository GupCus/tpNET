using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using System.Net.Http.Json;

namespace API.Clients
{
    public class UsuarioClient
    {
        private readonly HttpClient client;


        public UsuarioClient(HttpClient client)
        {
            this.client = client;
        }
    
    public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            IEnumerable<UsuarioDTO> usuarios = null;
            HttpResponseMessage response = await client.GetAsync("/usuario/");
            if (response.IsSuccessStatusCode) {
                usuarios= await response.Content.ReadFromJsonAsync<IEnumerable<UsuarioDTO>>();
            }
            return usuarios;
        }
        public async Task<UsuarioDTO> GetAsync(int id)
        {
            UsuarioDTO usuarioDTO = null;
            HttpResponseMessage response=await client.GetAsync("/usuario/"+id);
            if (response.IsSuccessStatusCode) {
                usuarioDTO = await response.Content.ReadFromJsonAsync<UsuarioDTO>();
            }
            return usuarioDTO;
        }
        public  async Task AddAsync(UsuarioDTO usuarioDTO)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/usuario", usuarioDTO);
            response.EnsureSuccessStatusCode();
        }

        public  async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("/usuario/" + id);
            response.EnsureSuccessStatusCode();
        }

        public  async Task UpdateAsync(UsuarioDTO usuarioDTO)
        {
            var updateDTO = new UsuarioUpdateDTO
            {
                Id = (int)usuarioDTO.Id,
                Nombre = usuarioDTO.Nombre,
                Mail = usuarioDTO.Mail
            };
            HttpResponseMessage response = await client.PutAsJsonAsync("/usuario/"+usuarioDTO.Id, usuarioDTO);
            response.EnsureSuccessStatusCode();
        }

    } }