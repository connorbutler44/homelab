using System.Threading.Tasks;
using Homelab.Domain;
using Homelab.Features.Finance.Importer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Homelab.Features.Finance;

public static class FinanceEndpoints
{
    public record ImportTransactionsRequest(
        FinanceAccountProvider ProviderKey,
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

    private static async Task<IResult> ImportTransactions(
        [FromForm] ImportTransactionsRequest request,
        ITransactionImporter importer)
    {
        await using var stream = request.File.OpenReadStream();

        await importer.ImportAsync(stream, request.ProviderKey);

        return Results.Ok("Import successful");
    }
}
