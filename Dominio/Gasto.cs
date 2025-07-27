using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Gasto
    {
        public CategoriaGasto CategoriaGasto { get; set; }
        public Participante Participante { get; set; }
        public float Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }
    }
}