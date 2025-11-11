using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ReporteGastosUsuarioDto
    {
        public string NombreUsuario { get; set; }
        public string MailUsuario { get; set; }
        public decimal TotalGastado { get; set; }
        public string Mail { get; set; }
    }

    public class ReporteGastosGrupoDto
    {
        public string NombreGrupo { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public List<ReporteGastosUsuarioDto> GastosUsuarios { get; set; }
        public decimal TotalGrupo => GastosUsuarios?.Sum(g => g.TotalGastado) ?? 0;
    }
}
