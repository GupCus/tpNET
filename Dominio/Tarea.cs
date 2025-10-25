using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public enum EstadoTarea
    {
        Activo,
        Pendiente
    }

    public class Tarea
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public DateTime? FechaHora { get; private set; }
        public int? Duracion { get; private set; }
        public string Descripcion { get; private set; }
        public EstadoTarea Estado { get; private set; }
        public DateTime FechaAlta { get; private set; }

        private readonly List<Gasto> _gastos = new List<Gasto>();
        public IReadOnlyCollection<Gasto> Gastos => _gastos.AsReadOnly();

        public Tarea(int id, string nombre, DateTime? fechaHora, int? duracion, string descripcion, EstadoTarea estado, DateTime fechaAlta)
        {
            SetId(id);
            SetNombre(nombre);
            SetFechaHora(fechaHora);
            SetDuracion(duracion);
            SetDescripcion(descripcion);
            SetEstado(estado);
            SetFechaAlta(fechaAlta);
        }

        public Tarea() { }

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

        public void SetFechaHora(DateTime? fechaHora)
        {
            FechaHora = fechaHora;
        }

        public void SetDuracion(int? duracion)
        {
            if (duracion.HasValue && duracion < 0) throw new ArgumentException("La duración no puede ser negativa.", nameof(duracion));
            Duracion = duracion;
        }

        public void SetDescripcion(string descripcion)
        {
            Descripcion = descripcion ?? string.Empty;
        }

        public void SetEstado(EstadoTarea estado)
        {
            Estado = estado;
        }

        public void SetFechaAlta(DateTime fechaAlta)
        {
            if (fechaAlta == default) throw new ArgumentException("La fecha de alta no puede ser nula.", nameof(fechaAlta));
            FechaAlta = fechaAlta;
        }

        public void AddGasto(Gasto gasto)
        {
            if (gasto == null) throw new ArgumentNullException(nameof(gasto));
            if (!_gastos.Contains(gasto)) _gastos.Add(gasto);
        }

        public void RemoveGasto(int gastoId)
        {
            var g = _gastos.FirstOrDefault(x => x.Id == gastoId);
            if (g != null) _gastos.Remove(g);
        }
    }
}