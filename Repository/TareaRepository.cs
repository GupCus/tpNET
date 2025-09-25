using Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class TareaRepository
    {
        public static async Task<Tarea[]?> GetAll()
        {
            using (PlanificadorContext bd = new())
            {
                return await bd.Tarea.ToArrayAsync();
            }
        }

        public static async Task<Tarea?> GetOne(int id)
        {
            using (PlanificadorContext bd = new())
            {
                return await bd.Tarea.FindAsync(id);
            }
        }
        public static async Task<Tarea> Post(Tarea t)
        {
            t.Id = null;
            using (PlanificadorContext bd = new())
            {
                await bd.Tarea.AddAsync(t);
                await bd.SaveChangesAsync();
                return t;
            }
        }

        public static async Task<Tarea?> Put(Tarea t)
        {
            using (PlanificadorContext bd = new())
            {
                Tarea? tModif = await bd.Tarea.FindAsync(t.Id);
                if (tModif != null)
                {
                    tModif.Nombre = t.Nombre;
                    tModif.FechaHora = t.FechaHora;
                    tModif.Duracion = t.Duracion;
                    tModif.Descripcion = t.Descripcion;
                    tModif.Estado = t.Estado;
                    tModif.Gastos = t.Gastos;
                    await bd.SaveChangesAsync();
                    return await bd.Tarea.FindAsync(t.Id);
                }
                return null;
            }
        }

        public static async Task<int?> Delete(int id)
        {
            using (PlanificadorContext bd = new())
            {
                var t = await bd.Tarea.FindAsync(id);
                if (t != null)
                {
                    bd.Tarea.Remove(t);
                    return await bd.SaveChangesAsync();
                }
                return null;
            }
        }
    }
}
