using System;
using System.Collections.Generic;

namespace DTOs
{
    // DTO para lectura/representación pública del usuario (sin contraseña)
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }

        // Opcional: lista de grupos a los que pertenece (solo datos básicos)
        public List<GrupoDTO>? Grupos { get; set; }
    }
}
