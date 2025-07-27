using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaHora { get; set; }
        public TimeOnly? Duracion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public List<Gasto> Gastos { get; set; }
    }
}