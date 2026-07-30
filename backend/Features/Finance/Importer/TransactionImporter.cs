using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Homelab.Data;
using Homelab.Data.Entities;
using Homelab.Domain;
using Microsoft.EntityFrameworkCore;

namespace Homelab.Features.Finance.Importer;

public class TransactionImporter(
    IEnumerable<ICsvParser> parsers,
    AppDbContext dbContext) : ITransactionImporter
{
    private readonly Dictionary<FinanceAccountProvider, ICsvParser> parsers = parsers.ToDictionary(x => x.Provider);

    public async Task<IReadOnlyList<FinanceTransaction>> ImportAsync(Stream file, FinanceAccountProvider provider)
    {
        var parser = parsers[provider];

        var account = await dbContext.FinanceAccounts.SingleAsync(x => x.Provider == provider);

        var parsedTransactions = await parser.ParseAsync(file, account.Id);

        await dbContext.FinanceTransactions.AddRangeAsync(parsedTransactions);
        await dbContext.SaveChangesAsync();

        return parsedTransactions;
    }
}