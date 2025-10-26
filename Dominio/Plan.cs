using System;

namespace Dominio
{
    public class Plan
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public DateOnly FechaInicio { get; private set; }
        public DateOnly FechaFin { get; private set; }
        public string Descripcion { get; private set; }
        public DateOnly FechaAlta { get; private set; }

        public Plan(int id, string nombre, DateOnly fechaInicio, DateOnly fechaFin, string descripcion,DateOnly fechaAlta)
        {
            SetId(id);
            SetNombre(nombre);
            SetFechaInicio(fechaInicio);
            SetFechaFin(fechaFin);
            SetDescripcion(descripcion);
            SetFechaAlta(fechaAlta);
           
        }

        public Plan() { }

        public void SetId(int id)
        {
            if (id < 0) throw new ArgumentException("El Id debe ser mayor o igual a 0.", nameof(id));
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetFechaInicio(DateOnly fechaInicio)
        {
            FechaInicio = fechaInicio;
        }

        public void SetFechaFin(DateOnly fechaFin)
        {
            if (fechaFin < FechaInicio) throw new ArgumentException("FechaFin no puede ser anterior a FechaInicio.", nameof(fechaFin));
            FechaFin = fechaFin;
        }

        public void SetDescripcion(string descripcion)
        {
            Descripcion = descripcion ?? string.Empty;
        }

        public void SetFechaAlta(DateOnly fechaAlta)
        {
            if (fechaAlta == default) throw new ArgumentException("La fecha de alta no puede ser nula.", nameof(fechaAlta));
            FechaAlta = fechaAlta;
        }
    }
}