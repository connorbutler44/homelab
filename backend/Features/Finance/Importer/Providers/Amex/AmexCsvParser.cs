using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Homelab.Data.Entities;
using Homelab.Domain;

namespace Homelab.Features.Finance.Importer.Providers.Amex;

public class AmexCsvParser : ICsvParser
{
    public FinanceAccountProvider Provider => FinanceAccountProvider.Amex;

    public Task<IReadOnlyList<FinanceTransaction>> ParseAsync(Stream file, Guid accountId)
    {
        using var reader = new StreamReader(file);

        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<AmexTransactionRow>().ToList();

        var transactions = records
            .Select(x =>
                new FinanceTransaction
                {
                    Amount = x.Amount,
                    Description = x.Description,
                    FinanceAccountId = accountId,
                    Date = x.Date,
                    ExtendedDetails = x.ExtendedDetails,
                    InternalId = x.Reference,
                }
            )
            .ToList();

        return Task.FromResult<IReadOnlyList<FinanceTransaction>>(transactions);
    }
}
