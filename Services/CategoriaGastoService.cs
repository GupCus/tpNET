using Dominio;
using Repository;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CategoriaGastoService
    {
        public CategoriaGastoDTO Add(CategoriaGastoDTO dto)
        {
            var repo = new CategoriaGastoRepository();

            if (repo.NameExists(dto.Tipo))
                throw new ArgumentException($"Ya existe una categoría con el tipo '{dto.Tipo}'.");

            var fechaAlta = DateTime.Now;
            var entidad = new CategoriaGasto(0, dto.Tipo, dto.Descripcion, fechaAlta);

            repo.Add(entidad);

            dto.Id = entidad.Id;
            dto.FechaAlta = entidad.FechaAlta;
            return dto;
        }

        public bool Delete(int id)
        {
            var repo = new CategoriaGastoRepository();
            return repo.Delete(id);
        }

        public CategoriaGastoDTO Get(int id)
        {
            var repo = new CategoriaGastoRepository();
            var c = repo.Get(id);
            if (c == null) return null;

            return new CategoriaGastoDTO
            {
                Id = c.Id,
                Tipo = c.Tipo,
                Descripcion = c.Descripcion,
                FechaAlta = c.FechaAlta
            };
        }

        public IEnumerable<CategoriaGastoDTO> GetAll()
        {
            var repo = new CategoriaGastoRepository();
            var items = repo.GetAll();
            return items.Select(c => new CategoriaGastoDTO
            {
                Id = c.Id,
                Tipo = c.Tipo,
                Descripcion = c.Descripcion,
                FechaAlta = c.FechaAlta
            }).ToList();
        }

        public bool Update(CategoriaGastoDTO dto)
        {
            var repo = new CategoriaGastoRepository();
            if (repo.NameExists(dto.Tipo, dto.Id))
                throw new ArgumentException($"Ya existe otra categoría con el tipo '{dto.Tipo}'.");

            var entidad = new CategoriaGasto(dto.Id, dto.Tipo, dto.Descripcion, dto.FechaAlta);
            return repo.Update(entidad);
        }

        public IEnumerable<CategoriaGastoDTO> GetByCriteria(CategoriaGastoCriteriaDTO criteriaDTO)
        {
            var repo = new CategoriaGastoRepository();
            var items = repo.GetByCriteria(criteriaDTO.Texto);
            return items.Select(c => new CategoriaGastoDTO
            {
                Id = c.Id,
                Tipo = c.Tipo,
                Descripcion = c.Descripcion,
                FechaAlta = c.FechaAlta
            });
        }
    }
}