using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Repository
{
    public class UsuarioRepository
    {
        private TPIContext CreateContext() => new TPIContext();

        public void Add(Usuario usuario)
        {
            using var ctx = CreateContext();
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var ctx = CreateContext();
            var u = ctx.Usuarios.Find(id);
            if (u == null) return false;
            ctx.Usuarios.Remove(u);
            ctx.SaveChanges();
            return true;
        }

        public Usuario? Get(int id)
        {
            using var ctx = CreateContext();
            return ctx.Usuarios
                .Include(u => u.GrupoUsuarios)
                    .ThenInclude(gu => gu.Grupo)
                .FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            using var ctx = CreateContext();
            return ctx.Usuarios
                .Include(u => u.GrupoUsuarios)
                    .ThenInclude(gu => gu.Grupo)
                .ToList();
        }

        public bool Update(Usuario usuario)
        {
            using var ctx = CreateContext();
            var existing = ctx.Usuarios.Find(usuario.Id);
            if (existing == null) return false;
            existing.SetMail(usuario.Mail);
            existing.SetNombre(usuario.Nombre);
            if (!string.IsNullOrWhiteSpace(usuario.Contrasena))
                existing.SetContrasena(usuario.Contrasena);
            existing.SetFechaAlta(usuario.FechaAlta);
            // Forzar SIEMPRE NoAdmin
            existing.SetRol("NoAdmin");
            ctx.SaveChanges();
            return true;
        }

        public bool EmailExists(string email, int? excludeId = null)
        {
            using var ctx = CreateContext();
            var q = ctx.Usuarios.Where(u => u.Mail.ToLower() == email.ToLower());
            if (excludeId.HasValue) q = q.Where(u => u.Id != excludeId.Value);
            return q.Any();
        }

        public IEnumerable<Usuario> GetByCriteria(string texto)
        {
            using var ctx = CreateContext();
            if (string.IsNullOrWhiteSpace(texto)) return ctx.Usuarios.ToList();
            texto = texto.ToLower();
            return ctx.Usuarios.Where(u => u.Mail.ToLower().Contains(texto) || u.Nombre.ToLower().Contains(texto)).ToList();
        }

        public Usuario GetByMail(string mail)
        {
            using var ctx = CreateContext();
            return ctx.Usuarios
                .FirstOrDefault(u => u.Mail.ToLower() == mail.ToLower());
        }

        public IEnumerable<Usuario> GetUsuariosPorGrupo(int grupoId)
        {
            using var ctx = CreateContext();
            return ctx.Usuarios
                .Include(u => u.GrupoUsuarios)
                .Where(u => u.GrupoUsuarios.Any(gu => gu.GrupoId == grupoId))
                .ToList();
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosPorGrupoAsync(int grupoId)
        {
            using var ctx = CreateContext();
            return await ctx.Usuarios
                .Include(u => u.GrupoUsuarios)
                .Where(u => u.GrupoUsuarios.Any(gu => gu.GrupoId == grupoId))
                .ToListAsync();
        }
    }
}