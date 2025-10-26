using Dominio;
using Repository;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class GrupoService
    {
        public GrupoDTO Add(GrupoDTO dto)
        {
            var repo = new GrupoRepository();

            if (repo.NameExists(dto.Nombre))
                throw new ArgumentException($"Ya existe un grupo con el nombre '{dto.Nombre}'.");

            var fechaAlta = DateTime.Now;
            var entidad = new Grupo(0, dto.Nombre, dto.Descripcion, fechaAlta);

            // Asociar usuarios si se envían Ids en DTO (opcional). Aquí asumimos que dto.Usuarios trae solo Ids si corresponde.
            if (dto.Usuarios != null && dto.Usuarios.Any())
            {
                var usuarioRepo = new UsuarioRepository();
                foreach (var u in dto.Usuarios)
                {
                    var usuario = usuarioRepo.Get(u.Id);
                    if (usuario != null) entidad.AddUsuario(usuario);
                }
            }

            repo.Add(entidad);

            dto.Id = entidad.Id;
            dto.FechaAlta = entidad.FechaAlta;
            return dto;
        }

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
                Usuarios = g.Usuarios?.Select(u => new UsuarioDTO { Id = u.Id, Nombre = u.Nombre, Mail = u.Mail }).ToList()
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
                FechaAlta = g.FechaAlta
            }).ToList();
        }

        public bool Update(GrupoDTO dto)
        {
            var repo = new GrupoRepository();
            if (repo.NameExists(dto.Nombre, dto.Id))
                throw new ArgumentException($"Ya existe otro grupo con el nombre '{dto.Nombre}'.");
            var entidad=repo.Get(dto.Id);
            entidad.SetDescripcion(dto.Descripcion);
            entidad.SetNombre(dto.Nombre);
            //var entidad = new Grupo(dto.Id, dto.Nombre, dto.Descripcion, dto.FechaAlta);

            // Si se proporciona lista de usuarios en DTO, sincronizar (simple enfoque)
            if (dto.Usuarios != null)
            {
                var usuarioRepo = new UsuarioRepository();
                // Limpiar y volver a agregar para simplicidad
                foreach (var usuarioDto in dto.Usuarios)
                {
                    var usuario = usuarioRepo.Get(usuarioDto.Id);
                    if (usuario != null) entidad.AddUsuario(usuario);
                }
            }

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
                FechaAlta = g.FechaAlta
            });
        }
    }
}