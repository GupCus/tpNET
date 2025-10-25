using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Application.Services
{
    public class UsuarioService
    {
        public UsuarioDTO Add(UsuarioUpdateDTO dto)
        {
            var repo = new UsuarioRepository();

            if (repo.EmailExists(dto.Mail))
                throw new ArgumentException($"Ya existe un usuario con el mail '{dto.Mail}'.");

            var fechaAlta = DateTime.Now;
            var entidad = new Usuario(0, dto.Mail, dto.Nombre, dto.Contrasena ?? string.Empty, fechaAlta);

            repo.Add(entidad);

            return new UsuarioDTO
            {
                Id = entidad.Id,
                Mail = entidad.Mail,
                Nombre = entidad.Nombre,
                FechaAlta = entidad.FechaAlta
            };
        }

        public bool Delete(int id)
        {
            var repo = new UsuarioRepository();
            return repo.Delete(id);
        }

        public UsuarioDTO Get(int id)
        {
            var repo = new UsuarioRepository();
            var u = repo.Get(id);
            if (u == null) return null;

            return new UsuarioDTO
            {
                Id = u.Id,
                Mail = u.Mail,
                Nombre = u.Nombre,
                FechaAlta = u.FechaAlta,
                Grupos = u.Grupos?.Select(g => new GrupoDTO { Id = g.Id, Nombre = g.Nombre, Descripcion = g.Descripcion, FechaAlta = g.FechaAlta }).ToList()
            };
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            var repo = new UsuarioRepository();
            var items = repo.GetAll();
            return items.Select(u => new UsuarioDTO
            {
                Id = u.Id,
                Mail = u.Mail,
                Nombre = u.Nombre,
                FechaAlta = u.FechaAlta
            }).ToList();
        }

        public bool Update(UsuarioUpdateDTO dto)
        {
            var repo = new UsuarioRepository();

            if (repo.EmailExists(dto.Mail, dto.Id))
                throw new ArgumentException($"Ya existe otro usuario con el mail '{dto.Mail}'.");

            var entidad = new Usuario(dto.Id, dto.Mail, dto.Nombre, dto.Contrasena ?? string.Empty, dto.FechaAlta);
            return repo.Update(entidad);
        }

        public IEnumerable<UsuarioDTO> GetByCriteria(UsuarioCriteriaDTO criteriaDTO)
        {
            var repo = new UsuarioRepository();
            var items = repo.GetByCriteria(criteriaDTO.Texto);
            return items.Select(u => new UsuarioDTO
            {
                Id = u.Id,
                Mail = u.Mail,
                Nombre = u.Nombre,
                FechaAlta = u.FechaAlta
            });
        }
    }
}