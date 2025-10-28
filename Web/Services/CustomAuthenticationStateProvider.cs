using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using DTOs;

namespace Web.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly SessionService _sessionService;

        public CustomAuthenticationStateProvider(SessionService sessionService)
        {
            _sessionService = sessionService;
            _sessionService.OnChange += NotifyAuthenticationStateChanged;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();

            if (_sessionService.UsuarioActual != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, _sessionService.UsuarioActual.Nombre ?? ""),
                    new Claim(ClaimTypes.Email, _sessionService.UsuarioActual.Mail ?? ""),
                    new Claim(ClaimTypes.NameIdentifier, _sessionService.UsuarioActual.Id.ToString()),
                    // Agrega más claims si los necesitas (roles, etc.)
                };

                identity = new ClaimsIdentity(claims, "apiauth");
            }

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }

        private void NotifyAuthenticationStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}