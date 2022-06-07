using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace Sociogram.UserInterface.Auth
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorage = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorage.Success ? userSessionStorage.Value : null;
                if (userSession == null)
                    return await Task.FromResult(new AuthenticationState(_anonymous));

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, userSession.Name),
                    new Claim(ClaimTypes.Email, userSession.Email)
                }, "CustomAuth"));

                    return await Task.FromResult(new AuthenticationState(claimsPrincipal));
                }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public async Task UpdateAuthenticationStateAsync(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal;
            if (userSession != null)
            {
                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, userSession.Name),
                    new Claim(ClaimTypes.Email, userSession.Email)
                }));
            }
            else
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = null;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
