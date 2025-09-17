using Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class CategoriaGastosRepository
    {
        public static async Task<CategoriaGasto[]> GetAll()
        {
            using (PlanificadorContext bd = new())
            {
                return await bd.CategoriaGastos.ToArrayAsync();
            }
        }

        public static async Task<CategoriaGasto?> GetOne(int id)
        {
            using (PlanificadorContext bd = new())
            {
                return await bd.CategoriaGastos.FindAsync(id);
            }
        }
        public static async Task<CategoriaGasto> Post(CategoriaGasto cg)
        {
            cg.Id = null;
            using (PlanificadorContext bd = new())
            {
                await bd.CategoriaGastos.AddAsync(cg);
                await bd.SaveChangesAsync();
                return cg;
            }
        }

        public static async Task<CategoriaGasto?> Put(CategoriaGasto cg)
        {
            using (PlanificadorContext bd = new())
            {
                CategoriaGasto? cgModif = await bd.CategoriaGastos.FindAsync(cg.Id);
                if (cgModif != null)
                {
                    cgModif.Descripcion = cg.Descripcion;
                    cgModif.Tipo = cg.Tipo;
                    await bd.SaveChangesAsync();
                    return await bd.CategoriaGastos.FindAsync(cg.Id);
                }
                return null;
            }
        }

        public static async Task<int?> Delete(int id)
        {
            using (PlanificadorContext bd = new())
            {
                var cg = await bd.CategoriaGastos.FindAsync(id);
                if(cg != null)
                {
                    bd.CategoriaGastos.Remove(cg);
                    return await bd.SaveChangesAsync();
                }
                return null;
            }
        }
    }
}
