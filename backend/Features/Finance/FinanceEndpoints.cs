using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Homelab.Features.Finance;

public static class FinanceEndpoints
{
    public static IEndpointRouteBuilder MapFinanceEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/finance/test", Test);

        return app;
    }

    private static async Task<IResult> Test()
    {
        Console.WriteLine("Test successful!");

        return Results.Ok("Test successful!");
    }
}
