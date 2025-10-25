using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Model
{
    public class Grupo
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public DateTime FechaAlta { get; private set; }

        private readonly List<Usuario> _usuarios = new List<Usuario>();
        public IReadOnlyCollection<Usuario> Usuarios => _usuarios.AsReadOnly();

        private readonly List<Plan> _planes = new List<Plan>();
        public IReadOnlyCollection<Plan> Planes => _planes.AsReadOnly();

        public Grupo(int id, string nombre, string descripcion, DateTime fechaAlta)
        {
            SetId(id);
            SetNombre(nombre);
            SetDescripcion(descripcion);
            SetFechaAlta(fechaAlta);
        }

        public Grupo() { }

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

        public void SetDescripcion(string descripcion)
        {
            Descripcion = descripcion ?? string.Empty;
        }

        public void SetFechaAlta(DateTime fechaAlta)
        {
            if (fechaAlta == default) throw new ArgumentException("La fecha de alta no puede ser nula.", nameof(fechaAlta));
            FechaAlta = fechaAlta;
        }

        public void AddUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            if (!_usuarios.Any(u => u.Id == usuario.Id)) _usuarios.Add(usuario);
            if (!usuario.Grupos.Any(g => g.Id == this.Id)) usuario.AddGrupo(this);
        }

        public void RemoveUsuario(int usuarioId)
        {
            var u = _usuarios.FirstOrDefault(x => x.Id == usuarioId);
            if (u != null)
            {
                _usuarios.Remove(u);
                u.RemoveGrupo(this.Id);
            }
        }

        public void AddPlan(Plan plan)
        {
            if (plan == null) throw new ArgumentNullException(nameof(plan));
            if (!_planes.Any(p => p.Id == plan.Id)) _planes.Add(plan);
        }

        public void RemovePlan(int planId)
        {
            var p = _planes.FirstOrDefault(x => x.Id == planId);
            if (p != null) _planes.Remove(p);
        }
    }
}
