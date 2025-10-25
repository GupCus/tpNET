using System;

namespace Dominio
{
    public class CategoriaGasto
    {
        public int Id { get; private set; }
        public string Tipo { get; private set; }
        public string Descripcion { get; private set; }

        public CategoriaGasto(int id, string tipo, string descripcion)
        {
            Id= id;
            Tipo= tipo;
            Descripcion= descripcion;
        }

        public CategoriaGasto() { }

        public void SetId(int id)
        {
            if (id < 0) throw new ArgumentException("El Id debe ser mayor o igual a 0.", nameof(id));
            Id = id;
        }

        public void SetTipo(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo)) throw new ArgumentException("El tipo no puede ser nulo o vacío.", nameof(tipo));
            Tipo = tipo;
        }

        public void SetDescripcion(string descripcion)
        {
            Descripcion = descripcion ?? string.Empty;
        }


    }
}