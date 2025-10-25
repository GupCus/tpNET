using Domain.Model;
using Data;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class PlanService
    {
        public PlanDTO Add(PlanDTO dto)
        {
            var repo = new PlanRepository();

            var fechaAlta = DateTime.Now;
            var entidad = new Plan(0, dto.Nombre, dto.FechaInicio, dto.FechaFin, dto.Descripcion, fechaAlta);

            repo.Add(entidad);

            dto.Id = entidad.Id;
            dto.FechaAlta = entidad.FechaAlta;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new PlanRepository();
            return repo.Delete(id);
        }

        public PlanDTO Get(int id)
        {
            var repo = new PlanRepository();
            var p = repo.Get(id);
            if (p == null) return null;

            return new PlanDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                FechaInicio = p.FechaInicio,
                FechaFin = p.FechaFin,
                Descripcion = p.Descripcion,
                FechaAlta = p.FechaAlta
            };
        }

        public IEnumerable<PlanDTO> GetAll()
        {
            var repo = new PlanRepository();
            var items = repo.GetAll();
            return items.Select(p => new PlanDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                FechaInicio = p.FechaInicio,
                FechaFin = p.FechaFin,
                Descripcion = p.Descripcion,
                FechaAlta = p.FechaAlta
            }).ToList();
        }

        public bool Update(PlanDTO dto)
        {
            var repo = new PlanRepository();
            var entidad = new Plan(dto.Id, dto.Nombre, dto.FechaInicio, dto.FechaFin, dto.Descripcion, dto.FechaAlta);
            return repo.Update(entidad);
        }

        public IEnumerable<PlanDTO> GetByCriteria(PlanCriteriaDTO criteriaDTO)
        {
            var repo = new PlanRepository();
            var items = repo.GetByCriteria(criteriaDTO.Texto);
            return items.Select(p => new PlanDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                FechaInicio = p.FechaInicio,
                FechaFin = p.FechaFin,
                Descripcion = p.Descripcion,
                FechaAlta = p.FechaAlta
            });
        }
    }
}