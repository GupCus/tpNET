using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dominio;

namespace Repository
{
    public class UsuarioRepository
    {


        public static async Task<Usuario[]?> GetAll()
        {
            using (PlanificadorContext bd = new())
            {
                return await bd.Usuario.ToArrayAsync();
            }

        }
        public static async Task<Usuario?> GetOne(int id)
        {
            using (PlanificadorContext bd = new())
            {
                return await bd.Usuario.FindAsync(id);
            }
        }
        public static async Task<Usuario?> Add(Usuario user)
        {
            
            using (PlanificadorContext bd = new())
            {
                await bd.Usuario.AddAsync(user);
                await bd.SaveChangesAsync();
                return user;
            }
        }
        public static async Task<Usuario?> Update(Usuario user)
        {
            using (PlanificadorContext bd = new())
            {
                Usuario? userAModificar = await bd.Usuario.FindAsync(user.Id);
                userAModificar.Nombre = user.Nombre;
                userAModificar.Mail = user.Mail;
                userAModificar.Contrasena = user.Contrasena;
                userAModificar.Grupos = user.Grupos;
                await bd.SaveChangesAsync();
                return await bd.Usuario.FindAsync(user.Id);

            }
        }
        public static async Task<int?> Delete(int id)
        {
            using (PlanificadorContext bd = new())
            {
                Usuario? userABorrar = await bd.Usuario.FindAsync(id);
                if (userABorrar != null)
                {
                    bd.Usuario.Remove(userABorrar);
                    return await bd.SaveChangesAsync();

                }
                return null;
            }
        }
    }
}
