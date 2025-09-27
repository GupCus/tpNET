using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Gasto : BaseClass
    {
        public int CategoriaGastoId { get; set; }
        public int UsuarioId { get; set; }
        public float Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }
    }
}