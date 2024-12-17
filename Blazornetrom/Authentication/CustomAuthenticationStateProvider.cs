using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components; // Pentru NavigationManager
using System.Security.Claims;

namespace BlazorServerAuthenticationAndAuthorization.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly NavigationManager _navigationManager; // Adaugă NavigationManager

        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage, NavigationManager navigationManager)
        {
            _sessionStorage = sessionStorage;
            _navigationManager = navigationManager; // Inițializează NavigationManager
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userSessionStorageResult = await _sessionStorage.GetAsync<Users>("UserSession");
            var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

            if (userSession == null)
                return new AuthenticationState(_anonymous);

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
    {
        new Claim(ClaimTypes.Name, userSession.Email),
        new Claim(ClaimTypes.Role, userSession.IsTrainer ? "Administrator" : "User")
    }, "CustomAuth"));

            return new AuthenticationState(claimsPrincipal);
        }



        public void UpdateAuthenticationState(Users userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if (userSession != null)
            {
                _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Email),
                    new Claim(ClaimTypes.Role, userSession.IsTrainer ? "Administrator" : "User")
                }));
            }
            else
            {
                _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task LogoutAsync()
        {
            Console.WriteLine("Ștergerea sesiunii...");
            await _sessionStorage.DeleteAsync("UserSession"); // Șterge sesiunea din storage
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous))); // Notifică schimbarea stării de autentificare
            Console.WriteLine("Sesiunea a fost ștearsă.");
        }

        public async Task Logout()
        {
            await LogoutAsync(); // Apelează LogoutAsync
            _navigationManager.NavigateTo("/"); // Navighează către pagina principală
        }
    }
}
