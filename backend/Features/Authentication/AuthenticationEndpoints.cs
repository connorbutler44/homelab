using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Homelab.Features.Authentication;

public static class AuthenticationEndpoints
{
    public record LoginRequest(
        string Username,
        string Password);

    public static IEndpointRouteBuilder MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/auth/login", Login)
            .AllowAnonymous();
        app.MapPost("/auth/logout", Logout);
        app.MapGet("/auth/me", Me);

        return app;
    }

    private static async Task<IResult> Login(
        LoginRequest request,
        AuthenticationService authService,
        HttpContext httpContext)
    {
        if (!authService.ValidateCredentials(request.Username, request.Password))
        {
            return Results.Unauthorized();
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, request.Username)
        };

        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);

        await httpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

        return Results.Ok();
    }

    private static async Task<IResult> Logout(HttpRequest httpRequest)
    {
        await httpRequest.HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return Results.Ok();
    }

    private static async Task<IResult> Me(ClaimsPrincipal user)
    {
        return Results.Ok(new
        {
            username = user.Identity?.Name
        });
    }
}
