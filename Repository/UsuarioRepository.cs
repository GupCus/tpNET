using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dominio;
using System.ComponentModel;
using System.Diagnostics;
using DTOs;

namespace Repository
{
    public class UsuarioRepository
    {

        private readonly PlanificadorContext bd;
        public UsuarioRepository(PlanificadorContext context)
        {
            bd = context;
        }
        public  async Task<IEnumerable<Usuario>> GetAll()
        {
            
            
                return await bd.Usuario.ToListAsync();
            

        }
        public  async Task CreateAdmin()
        {
            
                var adminExistente = await bd.Usuario.FirstOrDefaultAsync(u => u.Nombre == "admin" && u.Contrasena == "123");

                if (adminExistente == null)
                {
                var admin = new Usuario("admin@admin.com", "admin");
                admin.Contrasena = "123";
                    await bd.Usuario.AddAsync(admin);
                    await bd.SaveChangesAsync();
                
            }
        }
        public  async Task<Usuario?> GetOne(int id)
        {
            
               return await bd.Usuario.FindAsync(id);
            
        }
        public  async Task<Usuario?> Add(Usuario user)
        {      

            
                await bd.Usuario.AddAsync(user);
                await bd.SaveChangesAsync();
                return user;
            
        }
        public  async Task<bool> Update(Usuario usuario)
        {
            
                Usuario? userAModificar = await bd.Usuario.FindAsync(usuario.Id);
            if (userAModificar == null) return false;
            userAModificar.Nombre = usuario.Nombre;
            userAModificar.Mail = usuario.Mail;
                await bd.SaveChangesAsync();
                return true;

            
        }
        public  async Task<bool> Delete(int id)
        {
            
                Usuario? userABorrar = await bd.Usuario.FindAsync(id);
                if (userABorrar != null)
                {
                    bd.Usuario.Remove(userABorrar);
                     await bd.SaveChangesAsync();
                return true;
                }
                return false;
            
        }
        public  bool EmailExists(string email, int? id = null)
        {
            
                var query = bd.Usuario.Where(u => u.Mail.ToLower() == email.ToLower());
                if (id.HasValue)
                {
                    query = query.Where(u => u.Id != id.Value);
                }
                return query.Any();
            }
        
    }
}
