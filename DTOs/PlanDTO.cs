using System;

namespace DTOs
{
    public class PlanDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
