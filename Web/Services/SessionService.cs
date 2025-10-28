using DTOs;

namespace Web.Services
{
    public class SessionService
    {
        public UsuarioDTO? UsuarioActual { get; private set; }
        public event Action? OnChange;

        public void SetUsuario(UsuarioDTO usuario)
        {
            UsuarioActual = usuario;
            OnChange?.Invoke();
        }

        public void Logout()
        {
            UsuarioActual = null;
            OnChange?.Invoke();
        }

        public bool IsAuthenticated => UsuarioActual != null;
    }
}