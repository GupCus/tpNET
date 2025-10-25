using System;
using System.Collections.Generic;

namespace DTOs
{
    // DTO para crear/actualizar usuario. La contraseña es opcional en actualizaciones.
    public class UsuarioUpdateDTO
    {
        // En creación Id puede ser 0; en actualización debe llevar el Id real
        public int Id { get; set; }

        public string Mail { get; set; }
        public string Nombre { get; set; }

        // Para creación debe proporcionarse; para actualización puede omitirse si no se cambia.
        public string? Contrasena { get; set; }

        // FechaAlta normalmente la establece el servidor; en update puede enviarse para mantenerla.
        public DateTime FechaAlta { get; set; }

        // Si necesitas asociar grupos al crear/editar, puedes usar una lista de ids:
        public List<int>? GrupoIds { get; set; }
    }
}
