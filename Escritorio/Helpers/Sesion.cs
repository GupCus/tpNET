using DTOs;

namespace Escritorio
{
    public static class Sesion
    {
        public static UsuarioDTO? UsuarioActual { get; set; }

        public static bool EsAdmin()
        {
            if (UsuarioActual?.Rol == null)
                return false;

            return UsuarioActual.Rol.Trim().ToLower() == "admin";
        }
    }
}