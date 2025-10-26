using Dominio;
using Repository;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UsuarioService
    {
        public UsuarioUpdateDTO Add(UsuarioUpdateDTO dto)
        {
            var repo = new UsuarioRepository();

            if (repo.EmailExists(dto.Mail))
                throw new ArgumentException($"Ya existe un usuario con el mail '{dto.Mail}'.");

            var fechaAlta = DateTime.Now;

            // Usa el rol del DTO, validando que sea "Admin" o "NoAdmin" (por seguridad)
            var rol = (dto.Rol == "Admin" || dto.Rol == "NoAdmin") ? dto.Rol : "NoAdmin";

            var entidad = new Usuario(0, dto.Mail, dto.Nombre, dto.Contrasena ?? string.Empty, fechaAlta, rol);

            repo.Add(entidad);

            return new UsuarioUpdateDTO
            {
                Id = entidad.Id,
                Mail = entidad.Mail,
                Nombre = entidad.Nombre,
                FechaAlta = entidad.FechaAlta,
                Rol = entidad.Rol
            };
        }

        public bool Delete(int id)
        {
            var repo = new UsuarioRepository();
            return repo.Delete(id);
        }

        public UsuarioUpdateDTO Get(int id)
        {
            var repo = new UsuarioRepository();
            var u = repo.Get(id);
            if (u == null) return null;

            return new UsuarioUpdateDTO
            {
                Id = u.Id,
                Mail = u.Mail,
                Nombre = u.Nombre,
                FechaAlta = u.FechaAlta,
                Rol = u.Rol,
                Grupos = u.Grupos?.Select(g => new GrupoDTO { Id = g.Id, Nombre = g.Nombre, Descripcion = g.Descripcion, FechaAlta = g.FechaAlta }).ToList()
            };
        }

        public IEnumerable<UsuarioUpdateDTO> GetAll()
        {
            var repo = new UsuarioRepository();
            var items = repo.GetAll();
            return items.Select(u => new UsuarioUpdateDTO
            {
                Id = u.Id,
                Mail = u.Mail,
                Nombre = u.Nombre,
                FechaAlta = u.FechaAlta,
                Rol = u.Rol
            }).ToList();
        }

        public bool Update(UsuarioUpdateDTO dto)
        {
            var repo = new UsuarioRepository();

            if (repo.EmailExists(dto.Mail, dto.Id))
                throw new ArgumentException($"Ya existe otro usuario con el mail '{dto.Mail}'.");

            // Traer usuario actual
            var usuarioActual = repo.Get(dto.Id);
            if (usuarioActual == null)
                throw new ArgumentException("El usuario no existe.");

            // Si la contraseña es nula o vacía, usar la actual
            var contrasenaFinal = string.IsNullOrEmpty(dto.Contrasena)
                ? usuarioActual.Contrasena
                : dto.Contrasena;

            // Siempre usar la fecha de alta original
            var fechaAltaFinal = usuarioActual.FechaAlta;

            // Usa el rol del DTO, validando que sea "Admin" o "NoAdmin"
            var rol = (dto.Rol == "Admin" || dto.Rol == "NoAdmin") ? dto.Rol : "NoAdmin";

            var entidad = new Usuario(dto.Id, dto.Mail, dto.Nombre, contrasenaFinal, fechaAltaFinal, rol);
            return repo.Update(entidad);
        }

        public IEnumerable<UsuarioUpdateDTO> GetByCriteria(UsuarioCriteriaDTO criteriaDTO)
        {
            var repo = new UsuarioRepository();
            var items = repo.GetByCriteria(criteriaDTO.Texto);
            return items.Select(u => new UsuarioUpdateDTO
            {
                Id = u.Id,
                Mail = u.Mail,
                Nombre = u.Nombre,
                FechaAlta = u.FechaAlta,
                Rol = u.Rol
            });
        }

        public bool Login(LoginDTO user)
        {
            var users = new UsuarioRepository().GetAll();
            var usuario = users.FirstOrDefault(u => u.Nombre == user.Usuario && u.Contrasena == user.Contrasena);
            return usuario != null;
        }
    }
}