using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

app.UseCors();

app.MapGet("/", () => "Hello Auth.Api!");

app.MapPost("/api/auth/login", (UserCredentials credentials) =>
{
    if (credentials.Username == "admin" && credentials.Password == "12345")
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, credentials.Username),
            new Claim(ClaimTypes.Role, "Admin")
        };

        // dotnet add package Microsoft.IdentityModel.JsonWebTokens
        var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-256-bit-secret-your-256-bit-secret-your-256-bit-secret"));


        var creds = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

        var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        var jwt = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);

        return Results.Ok(new { accessToken = jwt });
    }


    return Results.Unauthorized();
});

app.Run();


record UserCredentials(string Username, string Password);