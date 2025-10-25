using Dominio;
using Repository;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class TareaService
    {
        public TareaDTO Add(TareaDTO dto)
        {
            var repo = new TareaRepository();

            var fechaAlta = DateTime.Now;
            var entidad = new Tarea(0, dto.Nombre, dto.FechaHora, dto.Duracion, dto.Descripcion, dto.Estado, fechaAlta);

            // Si se envían gastos en el DTO, opcionalmente asociarlos (se asume que Gastos vienen con Ids o datos mínimos)
            if (dto.Gastos != null && dto.Gastos.Any())
            {
                var gastoRepo = new GastoRepository();
                foreach (var gDto in dto.Gastos)
                {
                    // Si el gasto ya existe, obtenerlo; si no, crear uno mínimo no persistente aquí.
                    var gastoExistente = gDto.Id > 0 ? gastoRepo.Get(gDto.Id) : null;
                    if (gastoExistente != null) entidad.AddGasto(gastoExistente);
                }
            }

            repo.Add(entidad);

            dto.Id = entidad.Id;
            dto.FechaAlta = entidad.FechaAlta;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new TareaRepository();
            return repo.Delete(id);
        }

        public TareaDTO Get(int id)
        {
            var repo = new TareaRepository();
            var t = repo.Get(id);
            if (t == null) return null;

            return new TareaDTO
            {
                Id = t.Id,
                Nombre = t.Nombre,
                FechaHora = t.FechaHora,
                Duracion = t.Duracion,
                Descripcion = t.Descripcion,
                Estado = t.Estado,
                FechaAlta = t.FechaAlta,
                Gastos = t.Gastos?.Select(g => new GastoDTO
                {
                    Id = g.Id,
                    CategoriaGastoId = g.CategoriaGastoId,
                    CategoriaGastoNombre = g.CategoriaGasto?.Tipo,
                    UsuarioId = g.UsuarioId,
                    UsuarioNombre = g.Usuario?.Nombre,
                    Monto = g.Monto,
                    Descripcion = g.Descripcion,
                    FechaHora = g.FechaHora,
                    FechaAlta = g.FechaAlta
                }).ToList()
            };
        }

        public IEnumerable<TareaDTO> GetAll()
        {
            var repo = new TareaRepository();
            var items = repo.GetAll();
            return items.Select(t => new TareaDTO
            {
                Id = t.Id,
                Nombre = t.Nombre,
                FechaHora = t.FechaHora,
                Duracion = t.Duracion,
                Descripcion = t.Descripcion,
                Estado = t.Estado,
                FechaAlta = t.FechaAlta,
                Gastos = t.Gastos?.Select(g => new GastoDTO
                {
                    Id = g.Id,
                    CategoriaGastoId = g.CategoriaGastoId,
                    CategoriaGastoNombre = g.CategoriaGasto?.Tipo,
                    UsuarioId = g.UsuarioId,
                    UsuarioNombre = g.Usuario?.Nombre,
                    Monto = g.Monto,
                    Descripcion = g.Descripcion,
                    FechaHora = g.FechaHora,
                    FechaAlta = g.FechaAlta
                }).ToList()
            }).ToList();
        }

        public bool Update(TareaDTO dto)
        {
            var repo = new TareaRepository();
            var entidad = new Tarea(dto.Id, dto.Nombre, dto.FechaHora, dto.Duracion, dto.Descripcion, dto.Estado, dto.FechaAlta);
            // Nota: sincronización de gastos debería manejarse con endpoints específicos si hace falta
            return repo.Update(entidad);
        }

        public IEnumerable<TareaDTO> GetByCriteria(TareaCriteriaDTO criteriaDTO)
        {
            var repo = new TareaRepository();
            var items = repo.GetByCriteria(criteriaDTO.Texto);
            return items.Select(t => new TareaDTO
            {
                Id = t.Id,
                Nombre = t.Nombre,
                FechaHora = t.FechaHora,
                Duracion = t.Duracion,
                Descripcion = t.Descripcion,
                Estado = t.Estado,
                FechaAlta = t.FechaAlta
            });
        }
    }
}