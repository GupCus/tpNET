using Dominio;
using Repository;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Dominio;

namespace Services
{
    public class GrupoService
    {
        public GrupoDTO Add(GrupoDTO dto)
        {
            var repo = new GrupoRepository();
            var usuarioGrupoService = new UsuarioGrupoService();

            if (repo.NameExists(dto.Nombre))
                throw new ArgumentException($"Ya existe un grupo con el nombre '{dto.Nombre}'.");

            var fechaAlta = DateTime.Now;

            // Crear la entidad grupo
            var entidad = new Grupo(0, dto.Nombre, dto.Descripcion, fechaAlta, dto.IdUsuarioAdministrador);

            // Guardar el grupo primero para obtener el ID
            repo.Add(entidad);

            // Ahora que el grupo tiene ID, crear la relación con el administrador
            if (dto.IdUsuarioAdministrador > 0)
            {
                try
                {
                    // Crear relación automáticamente usando el servicio existente
                    usuarioGrupoService.Add(dto.IdUsuarioAdministrador, entidad.Id);
                }
                catch (ArgumentException ex)
                {
                    // Si ya existe la relación, continuar (no es un error crítico)
                    if (!ex.Message.Contains("ya existe"))
                        throw;
                }
            }

            // Relacionar otros usuarios si se proporcionan
            if (dto.Usuarios != null && dto.Usuarios.Any())
            {
                foreach (var usuarioDto in dto.Usuarios)
                {
                    if (usuarioDto.Id == dto.IdUsuarioAdministrador) continue; // Evitar duplicar admin

                    try
                    {
                        usuarioGrupoService.Add(usuarioDto.Id, entidad.Id);
                    }
                    catch (ArgumentException ex)
                    {
                        if (!ex.Message.Contains("ya existe"))
                            throw;
                    }
                }
            }

            // Retornar el DTO con los datos actualizados
            return new GrupoDTO
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Descripcion = entidad.Descripcion,
                FechaAlta = entidad.FechaAlta,
                IdUsuarioAdministrador = entidad.IdUsuarioAdministrador
            };
        }

        // El resto de los métodos permanecen igual...
        public bool Delete(int id)
        {
            var repo = new GrupoRepository();
            return repo.Delete(id);
        }

        public GrupoDTO Get(int id)
        {
            var repo = new GrupoRepository();
            var g = repo.Get(id);
            if (g == null) return null;

            return new GrupoDTO
            {
                Id = g.Id,
                Nombre = g.Nombre,
                Descripcion = g.Descripcion,
                FechaAlta = g.FechaAlta,
                IdUsuarioAdministrador = g.IdUsuarioAdministrador,
                Usuarios = g.GrupoUsuarios?.Select(gu => new UsuarioDTO
                {
                    Id = gu.UsuarioId,
                    Nombre = gu.Usuario?.Nombre,
                    Mail = gu.Usuario?.Mail
                }).ToList()
            };
        }

        public IEnumerable<GrupoDTO> GetAll()
        {
            var repo = new GrupoRepository();
            var items = repo.GetAll();
            return items.Select(g => new GrupoDTO
            {
                Id = g.Id,
                Nombre = g.Nombre,
                Descripcion = g.Descripcion,
                FechaAlta = g.FechaAlta,
                IdUsuarioAdministrador = g.IdUsuarioAdministrador
            }).ToList();
        }

        public bool Update(GrupoDTO dto)
        {
            var repo = new GrupoRepository();
            if (repo.NameExists(dto.Nombre, dto.Id))
                throw new ArgumentException($"Ya existe otro grupo con el nombre '{dto.Nombre}'.");

            var entidad = repo.Get(dto.Id);
            entidad.SetDescripcion(dto.Descripcion);
            entidad.SetNombre(dto.Nombre);
            entidad.SetIdUsuarioAdministrador(dto.IdUsuarioAdministrador);

            return repo.Update(entidad);
        }

        public IEnumerable<GrupoDTO> GetByCriteria(GrupoCriteriaDTO criteriaDTO)
        {
            var repo = new GrupoRepository();
            var items = repo.GetByCriteria(criteriaDTO.Texto);
            return items.Select(g => new GrupoDTO
            {
                Id = g.Id,
                Nombre = g.Nombre,
                Descripcion = g.Descripcion,
                FechaAlta = g.FechaAlta,
                IdUsuarioAdministrador = g.IdUsuarioAdministrador
            });
        }

        public IEnumerable<GrupoDTO> GetByAdministrador(int idAdministrador)
        {
            var repo = new GrupoRepository();
            var items = repo.GetAll().Where(g => g.IdUsuarioAdministrador == idAdministrador);
            return items.Select(g => new GrupoDTO
            {
                Id = g.Id,
                Nombre = g.Nombre,
                Descripcion = g.Descripcion,
                FechaAlta = g.FechaAlta,
                IdUsuarioAdministrador = g.IdUsuarioAdministrador,
                Usuarios = g.GrupoUsuarios?.Select(gu => new UsuarioDTO
                {
                    Id = gu.UsuarioId,
                    Nombre = gu.Usuario?.Nombre,
                    Mail = gu.Usuario?.Mail
                }).ToList()
            }).ToList();
        }

        public IEnumerable<GrupoDTO> GetByUsuario(int idUsuario)
        {
            var repo = new GrupoRepository();

            // Obtener grupos donde el usuario es administrador O es miembro
            var items = repo.GetAll()
                .Where(g => g.IdUsuarioAdministrador == idUsuario ||
                           g.GrupoUsuarios?.Any(gu => gu.UsuarioId == idUsuario) == true);

            return items.Select(g => new GrupoDTO
            {
                Id = g.Id,
                Nombre = g.Nombre,
                Descripcion = g.Descripcion,
                FechaAlta = g.FechaAlta,
                IdUsuarioAdministrador = g.IdUsuarioAdministrador,
                Usuarios = g.GrupoUsuarios?.Select(gu => new UsuarioDTO
                {
                    Id = gu.UsuarioId,
                    Nombre = gu.Usuario?.Nombre,
                    Mail = gu.Usuario?.Mail
                }).ToList()
            }).ToList();
        }
    }
}