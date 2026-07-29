using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Homelab.Features.Finance;

public static class FinanceEndpoints
{
    public record ImportTransactionsRequest(
        FinanceAccount Account,
        IFormFile File);

    public enum FinanceAccount
    {
        Chase,
        Amex,
        Ncsecu
    }

    public static IEndpointRouteBuilder MapFinanceEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/finance/import/transactions", ImportTransactions);

        return app;
    }

    private static async Task<IResult> ImportTransactions([FromForm] ImportTransactionsRequest request)
    {

        return Results.Ok("Import successful");
    }
}
