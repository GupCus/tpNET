using Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class GastoRepository
    {
        public static async Task<Gasto[]?> GetAll()
        {
            using (PlanificadorContext bd = new())
            {
                return await bd.Gasto.ToArrayAsync();
            }
        }

        public static async Task<Gasto?> GetOne(int id)
        {
            using (PlanificadorContext bd = new())
            {
                return await bd.Gasto.FindAsync(id);
            }
        }
        public static async Task<Gasto> Post(Gasto g)
        {
            g.Id = null;
            using (PlanificadorContext bd = new())
            {
                await bd.Gasto.AddAsync(g);
                await bd.SaveChangesAsync();
                return g;
            }
        }

        public static async Task<Gasto?> Put(Gasto g)
        {
            using (PlanificadorContext bd = new())
            {
                Gasto? gModif = await bd.Gasto.FindAsync(g.Id);
                if (gModif != null)
                {
                    gModif.CategoriaGastoId = g.CategoriaGastoId;
                    gModif.UsuarioId = g.UsuarioId;
                    gModif.Monto = g.Monto;
                    gModif.Descripcion = g.Descripcion;
                    gModif.FechaHora = g.FechaHora;
                    await bd.SaveChangesAsync();
                    return await bd.Gasto.FindAsync(g.Id);
                }
                return null;
            }
        }

        public static async Task<int?> Delete(int id)
        {
            using (PlanificadorContext bd = new())
            {
                var g = await bd.Gasto.FindAsync(id);
                if (g != null)
                {
                    bd.Gasto.Remove(g);
                    return await bd.SaveChangesAsync();
                }
                return null;
            }
        }
    }
}