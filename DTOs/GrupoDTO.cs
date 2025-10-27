using System;
using System.Collections.Generic;

namespace DTOs
{
    public class GrupoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdUsuarioAdministrador { get; set; } 
        public List<UsuarioDTO>? Usuarios { get; set; }
    }
}
