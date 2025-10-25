using System;
using System.Collections.Generic;
using Dominio; 

namespace DTOs
{
    public class TareaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaHora { get; set; }
        public int? Duracion { get; set; }
        public string Descripcion { get; set; }
        public EstadoTarea Estado { get; set; }
        public DateTime FechaAlta { get; set; }

        public List<GastoDTO>? Gastos { get; set; }
    }
}
