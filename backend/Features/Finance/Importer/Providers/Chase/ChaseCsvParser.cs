using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Homelab.Data.Entities;
using Homelab.Domain;

namespace Homelab.Features.Finance.Importer.Providers.Chase;

public class ChaseCsvParser : ICsvParser
{
    public FinanceAccountProvider Provider => FinanceAccountProvider.Chase;

    public Task<IReadOnlyList<FinanceTransaction>> ParseAsync(Stream file, Guid accountId)
    {
        Console.WriteLine("Hello from Chase CSV parser");
        return Task.FromResult<IReadOnlyList<FinanceTransaction>>(new List<FinanceTransaction>());
    }
}
