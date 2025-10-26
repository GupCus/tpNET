using System;
using System.Collections.Generic;

namespace DTOs
{
    public class UsuarioUpdateDTO
    {
        public int Id { get; set; }

        public string Mail { get; set; }
        public string Nombre { get; set; }

        public string? Contrasena { get; set; }

        public DateTime FechaAlta { get; set; }

        public string Rol { get; set; }

        public List<GrupoDTO>? Grupos { get; set; }
    }
}
