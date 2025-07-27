using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Plan
    {
        public int Id { get; set; }
        public List<Tarea> Tareas { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public string Descripcion { get; set; }

    }
}