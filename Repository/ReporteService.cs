using System;
using System.Collections.Generic;

namespace DTOs
{
    public class ReportePreciosUsuarioDTO
    {
        public string GrupoNombre { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public List<UsuarioPreciosDTO> Usuarios { get; set; } = new List<UsuarioPreciosDTO>();
        public decimal TotalGeneral { get; set; }

        // ✅ NUEVAS PROPIEDADES PARA GRÁFICOS
        public List<DatosGraficoTorta> DatosGraficoTorta { get; set; } = new List<DatosGraficoTorta>();
        public List<double> DatosBoxPlot { get; set; } = new List<double>();
    }

    public class UsuarioPreciosDTO
    {
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioEmail { get; set; }
        public List<GastoUsuarioDTO> Gastos { get; set; } = new List<GastoUsuarioDTO>();
        public decimal TotalUsuario { get; set; }
    }

    public class GastoUsuarioDTO
    {
        public string TareaNombre { get; set; }
        public string CategoriaGasto { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaHora { get; set; }
    }

    // ✅ NUEVO DTO PARA DATOS DEL GRÁFICO DE TORTA
    public class DatosGraficoTorta
    {
        public string Etiqueta { get; set; }
        public decimal Valor { get; set; }
        public string Color { get; set; }
    }
}
