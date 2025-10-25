using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class PlanRepository
    {
        private TPIContext CreateContext() => new TPIContext();

        public void Add(Plan plan)
        {
            using var ctx = CreateContext();
            ctx.Planes.Add(plan);
            ctx.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var ctx = CreateContext();
            var p = ctx.Planes.Find(id);
            if (p == null) return false;
            ctx.Planes.Remove(p);
            ctx.SaveChanges();
            return true;
        }

        public Plan? Get(int id)
        {
            using var ctx = CreateContext();
            return ctx.Planes.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Plan> GetAll()
        {
            using var ctx = CreateContext();
            return ctx.Planes.ToList();
        }

        public bool Update(Plan plan)
        {
            using var ctx = CreateContext();
            var existing = ctx.Planes.Find(plan.Id);
            if (existing == null) return false;
            existing.SetNombre(plan.Nombre);
            existing.SetFechaInicio(plan.FechaInicio);
            existing.SetFechaFin(plan.FechaFin);
            existing.SetDescripcion(plan.Descripcion);
            existing.SetFechaAlta(plan.FechaAlta);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Plan> GetByCriteria(string texto)
        {
            using var ctx = CreateContext();
            if (string.IsNullOrWhiteSpace(texto)) return ctx.Planes.ToList();
            texto = texto.ToLower();
            return ctx.Planes.Where(p => p.Nombre.ToLower().Contains(texto) || (p.Descripcion != null && p.Descripcion.ToLower().Contains(texto))).ToList();
        }
    }
}
