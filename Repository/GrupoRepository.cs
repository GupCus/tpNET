using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dominio;
namespace Repository
{
    public class GrupoRepository
    {
        public async static Task<Grupo[]?> GetAll()
        {
            using (PlanificadorContext db = new())
            {
                return await db.Grupo.ToArrayAsync();
            }

        }
        public async static Task<Grupo?> GetOne(int id)
        {
            using (PlanificadorContext db = new())
            {
                return await db.Grupo.FindAsync(id);
            }
        }
        public async static Task<Grupo?> Post(Grupo gru)
        {
            using (PlanificadorContext db = new())
            {
                await db.Grupo.AddAsync(gru);
                await db.SaveChangesAsync();
                return gru;
            }
        }
        public async static Task<Grupo?> Put(Grupo gru)
        {
            using (PlanificadorContext db = new())
            {
                Grupo? grupoAModificar = await db.Grupo.FindAsync(gru.Id);
                if (grupoAModificar != null)
                {
                    grupoAModificar.Planes = gru.Planes;
                    grupoAModificar.Usuarios = gru.Usuarios;
                    grupoAModificar.Nombre = gru.Nombre;
                    await db.SaveChangesAsync();
                    return await db.Grupo.FindAsync(grupoAModificar.Id);

                }
                return null;
            }
        }
        public static async Task<int?> Delete(int id)
        {
            using (PlanificadorContext db = new())
            {
                var grupo = await db.Grupo.FindAsync(id);
                if (grupo != null)
                {
                    db.Grupo.Remove(grupo);
                    return await db.SaveChangesAsync();

                }
                return null;
            }
        }
    }
}
