using System;
using System.Collections.Generic;
using DTOs;
using Dominio;
using Repository;
using System.Linq;
using Dominio.Dominio;

namespace Services
{
    public class UsuarioGrupoService
    {
        private readonly UsuarioGrupoRepository _repo = new UsuarioGrupoRepository();

        public void Add(int usuarioId, int grupoId)
        {
            var existe = _repo.Get(usuarioId, grupoId);
            if (existe != null)
                throw new ArgumentException("La relación usuario-grupo ya existe.");

            var rel = new UsuarioGrupo
            {
                GrupoId = grupoId,
                UsuarioId = usuarioId,
                FechaAlta = DateTime.Now
            };
            _repo.Add(rel);
        }

        public bool Delete(int usuarioId, int grupoId)
        {
            return _repo.Delete(usuarioId, grupoId);
        }

        public IEnumerable<GrupoDTO> GetGruposDeUsuario(int usuarioId)
        {
            var relaciones = _repo.GetByUsuario(usuarioId);
            return relaciones.Select(gu => new GrupoDTO
            {
                Id = gu.GrupoId,
                Nombre = gu.Grupo?.Nombre,
                Descripcion = gu.Grupo?.Descripcion,
                FechaAlta = gu.Grupo?.FechaAlta ?? DateTime.MinValue
            });
        }

        public IEnumerable<UsuarioDTO> GetUsuariosDeGrupo(int grupoId)
        {
            var relaciones = _repo.GetByGrupo(grupoId);
            return relaciones.Select(gu => new UsuarioDTO
            {
                Id = gu.UsuarioId,
                Nombre = gu.Usuario?.Nombre,
                Mail = gu.Usuario?.Mail,
                FechaAlta = gu.Usuario?.FechaAlta ?? DateTime.MinValue
            });
        }
    }
}
