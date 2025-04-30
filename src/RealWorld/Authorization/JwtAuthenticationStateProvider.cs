using Microsoft.AspNetCore.Components.Authorization;

namespace RealWorld.Authorization;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // TODO: Add logic to retrieve the authentication state from a JWT token 

        return new AuthenticationState(new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity()));
    }
}
