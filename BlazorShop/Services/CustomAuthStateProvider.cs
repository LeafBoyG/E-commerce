using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorShop.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_currentUser));
        }

        public void Login(string email)
        {
            // Create a fake user identity
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, email),
            }, "Fake Authentication Type");

            _currentUser = new ClaimsPrincipal(identity);
            
            // Notify the app that the user state has changed
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void Logout()
        {
            // Reset to anonymous user
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}