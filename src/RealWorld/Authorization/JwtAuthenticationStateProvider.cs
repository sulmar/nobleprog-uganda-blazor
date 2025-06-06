﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace RealWorld.Authorization;

public class JwtAuthenticationStateProvider(ILocalStorageService localStorage, IJSRuntime JS) : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await localStorage.GetItemAsStringAsync("access_token");

        await JS.InvokeVoidAsync("console.log", "Token: " + token);

        var value = await JS.InvokeAsync<string>("localStorage.getItem", "a");


        if (!string.IsNullOrEmpty(token))
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var claims = jwt.Claims.ToList();
            var identity = new System.Security.Claims.ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }


        return new AuthenticationState(new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity()));
    }
}
