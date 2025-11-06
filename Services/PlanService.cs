using Dominio;
using Repository;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class PlanService
    {
        public PlanCreateDTO Add(PlanCreateDTO dto)
        {
            var repo = new PlanRepository();

            var fechaAlta = DateTime.Now;
            var entidad = new Plan(0, dto.Nombre, dto.FechaInicio, dto.FechaBaja, dto.Descripcion, DateOnly.FromDateTime(fechaAlta), dto.GrupoId);

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
                FechaAlta = p.FechaAlta,
                GrupoId = p.GrupoId
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
                FechaAlta = p.FechaAlta,
                GrupoId = p.GrupoId
            }).ToList();
        }

        public bool Update(PlanUpdateDTO dto)
        {
            var repo = new PlanRepository();

            var entidad = repo.Get(dto.Id);
            if (entidad == null) throw new Exception("Plan no encontrado");
            entidad.SetNombre(dto.Nombre);
            entidad.SetFechaInicio(DateOnly.FromDateTime(dto.FechaInicio));
            entidad.SetDescripcion(dto.Descripcion);
            entidad.SetFechaFin(DateOnly.FromDateTime(dto.FechaFin));
            entidad.SetGrupoId(dto.GrupoId);
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
                FechaAlta = p.FechaAlta,
                GrupoId = p.GrupoId
            });
        }

        //Devuelve todos los planes de un grupo dado por su id.
        public IEnumerable<PlanDTO> GetByGrupoId(int grupoId)
        {
            var repo = new PlanRepository();

            var items = repo.GetAll().Where(p => p.GrupoId == grupoId);

            return items.Select(p => new PlanDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                FechaInicio = p.FechaInicio,
                FechaFin = p.FechaFin,
                Descripcion = p.Descripcion,
                FechaAlta = p.FechaAlta,
                GrupoId = p.GrupoId
            }).ToList();
        }
    }
}