using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Homelab.Data.Entities;
using Homelab.Domain;

namespace Homelab.Features.Finance.Importer.Providers.Ncsecu;

public class NcsecuCsvParser : ICsvParser
{
    public FinanceAccountProvider Provider => FinanceAccountProvider.Ncsecu;

    public Task<IReadOnlyList<FinanceTransaction>> ParseAsync(Stream file)
    {
        Console.WriteLine("Hello from Ncsecu CSV parser");
        return Task.FromResult<IReadOnlyList<FinanceTransaction>>(new List<FinanceTransaction>());
    }
}
