using System;

namespace DTOs
{
    public class PlanCreateDTO
    {
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaBaja { get; set; }
        public string Descripcion { get; set; }
        public DateOnly FechaAlta { get; set; }

    }
}
