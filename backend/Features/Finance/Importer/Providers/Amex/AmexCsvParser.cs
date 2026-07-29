using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Homelab.Data.Entities;
using Homelab.Domain;

namespace Homelab.Features.Finance.Importer.Providers.Amex;

public class AmexCsvParser : ICsvParser
{
    public FinanceAccountProvider Provider => FinanceAccountProvider.Amex;

    public Task<IReadOnlyList<FinanceTransaction>> ParseAsync(Stream file)
    {
        Console.WriteLine("Hello from Amex CSV parser");
        return Task.FromResult<IReadOnlyList<FinanceTransaction>>(new List<FinanceTransaction>());
    }
}
