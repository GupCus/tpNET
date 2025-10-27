using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Dominio;
using Dominio.Dominio;

namespace Repository
{
    public class UsuarioGrupoRepository
    {
        private TPIContext CreateContext() => new TPIContext();

        public void Add(UsuarioGrupo usuarioGrupo)
        {
            using var ctx = CreateContext();
            ctx.GrupoUsuarios.Add(usuarioGrupo);
            ctx.SaveChanges();
        }

        public bool Delete(int usuarioId, int grupoId)
        {
            using var ctx = CreateContext();
            var rel = ctx.GrupoUsuarios.Find(grupoId, usuarioId);
            if (rel == null) return false;
            ctx.GrupoUsuarios.Remove(rel);
            ctx.SaveChanges();
            return true;
        }

        public UsuarioGrupo? Get(int usuarioId, int grupoId)
        {
            using var ctx = CreateContext();
            return ctx.GrupoUsuarios
                .Include(gu => gu.Usuario)
                .Include(gu => gu.Grupo)
                .FirstOrDefault(gu => gu.UsuarioId == usuarioId && gu.GrupoId == grupoId);
        }

        public IEnumerable<UsuarioGrupo> GetByUsuario(int usuarioId)
        {
            using var ctx = CreateContext();
            return ctx.GrupoUsuarios
                .Include(gu => gu.Grupo)
                .Where(gu => gu.UsuarioId == usuarioId)
                .ToList();
        }

        public IEnumerable<UsuarioGrupo> GetByGrupo(int grupoId)
        {
            using var ctx = CreateContext();
            return ctx.GrupoUsuarios
                .Include(gu => gu.Usuario)
                .Where(gu => gu.GrupoId == grupoId)
                .ToList();
        }
    }
}
