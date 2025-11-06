using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Repository
{
    public class TareaRepository
    {
        private TPIContext CreateContext() => new TPIContext();

        public void Add(Tarea tarea)
        {
            using var ctx = CreateContext();
            ctx.Tareas.Add(tarea);
            ctx.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var ctx = CreateContext();
            var t = ctx.Tareas.Find(id);
            if (t == null) return false;
            ctx.Tareas.Remove(t);
            ctx.SaveChanges();
            return true;
        }

        public Tarea? Get(int id)
        {
            using var ctx = CreateContext();
            return ctx.Tareas.Include(t => t.Gastos).FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Tarea> GetAll()
        {
            using var ctx = CreateContext();
            return ctx.Tareas.Include(t => t.Gastos).ToList();
        }

        public bool Update(Tarea tarea)
        {
            using var ctx = CreateContext();
            var existing = ctx.Tareas.Find(tarea.Id);
            if (existing == null) return false;
            existing.SetNombre(tarea.Nombre);
            existing.SetFechaHora(tarea.FechaHora);
            existing.SetDuracion(tarea.Duracion);
            existing.SetDescripcion(tarea.Descripcion);
            existing.SetEstado(tarea.Estado);
            existing.SetFechaAlta(tarea.FechaAlta);
            existing.SetPlanId(tarea.PlanId);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Tarea> GetByCriteria(string texto)
        {
            using var ctx = CreateContext();
            if (string.IsNullOrWhiteSpace(texto)) return ctx.Tareas.ToList();
            texto = texto.ToLower();
            return ctx.Tareas.Where(t => t.Nombre.ToLower().Contains(texto) || (t.Descripcion != null && t.Descripcion.ToLower().Contains(texto))).ToList();
        }

        public IEnumerable<Tarea> GetByPlanId(int planId)
        {
            using var ctx = CreateContext();
            return ctx.Tareas
                .Include(t => t.Gastos)
                .Where(t => t.PlanId == planId)
                .ToList();
        }

        public IEnumerable<Usuario> GetUsuariosPorGrupo(int grupoId)
        {
            using var ctx = CreateContext();
            return ctx.Usuarios
                .Include(u => u.GrupoUsuarios)
                .Where(u => u.GrupoUsuarios.Any(gu => gu.GrupoId == grupoId))
                .ToList();
        }
    }
}