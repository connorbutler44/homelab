using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Homelab.Data.Entities;
using Homelab.Domain;

namespace Homelab.Features.Finance.Importer;

public class TransactionImporter(IEnumerable<ICsvParser> parsers) : ITransactionImporter
{
    private readonly Dictionary<FinanceAccountProvider, ICsvParser> parsers = parsers.ToDictionary(x => x.Provider);

    public Task<IReadOnlyList<FinanceTransaction>> ImportAsync(Stream file, FinanceAccountProvider provider)
    {
        var parser = parsers[provider];

        var parsedTransactions = parser.ParseAsync(file);

        return parsedTransactions;
    }
}