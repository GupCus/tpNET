
using System;

namespace Dominio
{
    public class Gasto
    {
        public int Id { get; private set; }

        private int _categoriaGastoId;
        private CategoriaGasto? _categoriaGasto;
        public int CategoriaGastoId
        {
            get => _categoriaGasto?.Id ?? _categoriaGastoId;
            private set => _categoriaGastoId = value;
        }
        public CategoriaGasto? CategoriaGasto
        {
            get => _categoriaGasto;
            private set
            {
                _categoriaGasto = value;
                if (value != null && _categoriaGastoId != value.Id) _categoriaGastoId = value.Id;
            }
        }

        private int _usuarioId;
        private Usuario? _usuario;
        public int UsuarioId
        {
            get => _usuario?.Id ?? _usuarioId;
            private set => _usuarioId = value;
        }
        public Usuario? Usuario
        {
            get => _usuario;
            private set
            {
                _usuario = value;
                if (value != null && _usuarioId != value.Id) _usuarioId = value.Id;
            }
        }

        public float Monto { get; private set; }
        public string Descripcion { get; private set; }
        public DateTime FechaHora { get; private set; }
        public DateTime FechaAlta { get; private set; }

        public Gasto(int id, int categoriaGastoId, int usuarioId, float monto, string descripcion, DateTime fechaHora, DateTime fechaAlta)
        {
            SetId(id);
            SetCategoriaGastoId(categoriaGastoId);
            SetUsuarioId(usuarioId);
            SetMonto(monto);
            SetDescripcion(descripcion);
            SetFechaHora(fechaHora);
            SetFechaAlta(fechaAlta);
        }

        public Gasto() { }

        public void SetId(int id)
        {
            if (id < 0) throw new ArgumentException("El Id debe ser mayor o igual a 0.", nameof(id));
            Id = id;
        }

        public void SetCategoriaGastoId(int categoriaGastoId)
        {
            if (categoriaGastoId <= 0) throw new ArgumentException("CategoriaGastoId debe ser mayor que 0.", nameof(categoriaGastoId));
            _categoriaGastoId = categoriaGastoId;
            if (_categoriaGasto != null && _categoriaGasto.Id != categoriaGastoId) _categoriaGasto = null;
        }

        public void SetCategoriaGasto(CategoriaGasto categoria)
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));
            _categoriaGasto = categoria;
            _categoriaGastoId = categoria.Id;
        }

        public void SetUsuarioId(int usuarioId)
        {
            if (usuarioId <= 0) throw new ArgumentException("UsuarioId debe ser mayor que 0.", nameof(usuarioId));
            _usuarioId = usuarioId;
            if (_usuario != null && _usuario.Id != usuarioId) _usuario = null;
        }

        public void SetUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            _usuario = usuario;
            _usuarioId = usuario.Id;
        }

        public void SetMonto(float monto)
        {
            if (monto < 0) throw new ArgumentException("El monto no puede ser negativo.", nameof(monto));
            Monto = monto;
        }

        public void SetDescripcion(string descripcion)
        {
            Descripcion = descripcion ?? string.Empty;
        }

        public void SetFechaHora(DateTime fechaHora)
        {
            if (fechaHora == default) throw new ArgumentException("FechaHora no puede ser nula.", nameof(fechaHora));
            FechaHora = fechaHora;
        }

        public void SetFechaAlta(DateTime fechaAlta)
        {
            if (fechaAlta == default) throw new ArgumentException("FechaAlta no puede ser nula.", nameof(fechaAlta));
            FechaAlta = fechaAlta;
        }
    }
}