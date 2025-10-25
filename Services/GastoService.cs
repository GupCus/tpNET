using Dominio;
using Repository;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class GastoService
    {
        public GastoDTO Add(GastoDTO dto)
        {
            var repo = new GastoRepository();

            var catRepo = new CategoriaGastoRepository();
            if (catRepo.Get(dto.CategoriaGastoId) == null)
                throw new ArgumentException($"No existe CategoriaGasto con Id {dto.CategoriaGastoId}.");

            var usuarioRepo = new UsuarioRepository();
            if (usuarioRepo.Get(dto.UsuarioId) == null)
                throw new ArgumentException($"No existe Usuario con Id {dto.UsuarioId}.");

            // Si hay tarea, podrías validar aquí si existe la Tarea
            // var tareaRepo = new TareaRepository();
            // if (dto.TareaId != null && tareaRepo.Get(dto.TareaId.Value) == null)
            //     throw new ArgumentException($"No existe Tarea con Id {dto.TareaId}.");

            var fechaHora = dto.FechaHora == default ? DateTime.Now : dto.FechaHora;
            var fechaAlta = DateTime.Now;

            var entidad = new Gasto(
                0,
                dto.CategoriaGastoId,
                dto.UsuarioId,
                dto.Monto,
                dto.Descripcion,
                fechaHora,
                fechaAlta,
                dto.TareaId 
            );

            repo.Add(entidad);

            dto.Id = entidad.Id;
            dto.FechaAlta = entidad.FechaAlta;
            dto.CategoriaGastoNombre = entidad.CategoriaGasto?.Tipo;
            dto.UsuarioNombre = entidad.Usuario?.Nombre;
            dto.TareaNombre = entidad.Tarea?.Nombre;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new GastoRepository();
            return repo.Delete(id);
        }

        public GastoDTO? Get(int id)
        {
            var repo = new GastoRepository();
            var g = repo.Get(id);
            if (g == null) return null;

            return new GastoDTO
            {
                Id = g.Id,
                CategoriaGastoId = g.CategoriaGastoId,
                CategoriaGastoNombre = g.CategoriaGasto?.Tipo,
                UsuarioId = g.UsuarioId,
                UsuarioNombre = g.Usuario?.Nombre,
                TareaId = g.TareaId,
                TareaNombre = g.Tarea?.Nombre,
                Monto = g.Monto,
                Descripcion = g.Descripcion,
                FechaHora = g.FechaHora,
                FechaAlta = g.FechaAlta
            };
        }

        public IEnumerable<GastoDTO> GetAll()
        {
            var repo = new GastoRepository();
            var items = repo.GetAll();
            return items.Select(g => new GastoDTO
            {
                Id = g.Id,
                CategoriaGastoId = g.CategoriaGastoId,
                CategoriaGastoNombre = g.CategoriaGasto?.Tipo,
                UsuarioId = g.UsuarioId,
                UsuarioNombre = g.Usuario?.Nombre,
                TareaId = g.TareaId,
                TareaNombre = g.Tarea?.Nombre,
                Monto = g.Monto,
                Descripcion = g.Descripcion,
                FechaHora = g.FechaHora,
                FechaAlta = g.FechaAlta
            }).ToList();
        }

        public bool Update(GastoDTO dto)
        {
            var repo = new GastoRepository();

            var entidad = new Gasto(
                dto.Id,
                dto.CategoriaGastoId,
                dto.UsuarioId,
                dto.Monto,
                dto.Descripcion,
                dto.FechaHora,
                dto.FechaAlta,
                dto.TareaId 
            );
            return repo.Update(entidad);
        }

        public IEnumerable<GastoDTO> GetByCriteria(GastoCriteriaDTO criteriaDTO)
        {
            var repo = new GastoRepository();
            var items = repo.GetByCriteria(criteriaDTO.Texto);
            return items.Select(g => new GastoDTO
            {
                Id = g.Id,
                CategoriaGastoId = g.CategoriaGastoId,
                CategoriaGastoNombre = g.CategoriaGasto?.Tipo,
                UsuarioId = g.UsuarioId,
                UsuarioNombre = g.Usuario?.Nombre,
                TareaId = g.TareaId,
                TareaNombre = g.Tarea?.Nombre,
                Monto = g.Monto,
                Descripcion = g.Descripcion,
                FechaHora = g.FechaHora,
                FechaAlta = g.FechaAlta
            });
        }
    }
}