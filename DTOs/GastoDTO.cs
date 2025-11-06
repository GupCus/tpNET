using System;

namespace DTOs
{
    public class GastoDTO
    {
        public int Id { get; set; }

        public int CategoriaGastoId { get; set; }
        public string? CategoriaGastoNombre { get; set; }

        public int UsuarioId { get; set; }
        public string? UsuarioNombre { get; set; }
        public int? TareaId { get; set; }
        public string? TareaNombre { get; set; }

        public float Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
