using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Homelab.Data.Entities;
using Homelab.Domain;

namespace Homelab.Features.Finance.Importer.Providers.Ncsecu;

public class NcsecuCsvParser : ICsvParser
{
    public FinanceAccountProvider Provider => FinanceAccountProvider.Ncsecu;

    public Task<IReadOnlyList<FinanceTransaction>> ParseAsync(Stream file, Guid accountId)
    {
        using var reader = new StreamReader(file);

        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        // skip first two rows
        csv.Read();
        csv.Read();
        csv.Read();
        csv.ReadHeader();

        var records = csv.GetRecords<NcsecuTransactionRow>().ToList();

        var transactions = records
            .Select(r =>
                new FinanceTransaction
                {
                    Amount = r.Debit ?? r.Credit
                        ?? throw new InvalidOperationException("Transaction missing amount"),
                    Description = r.Description,
                    FinanceAccountId = accountId,
                    Date = r.Date,
                    ExtendedDetails = "",
                    InternalId = CreateTransactionHash(r),
                }
            )
            .ToList();

        return Task.FromResult<IReadOnlyList<FinanceTransaction>>(transactions);
    }

    /// <summary>
    /// Generates a unique identifier for a given row since the export does not provide one.
    /// There's a possibility for this to clash if there are multiple transactions for the same amount and same item.
    /// </summary>
    public static string CreateTransactionHash(NcsecuTransactionRow row)
    {

        var canonical = string.Join("|",
            row.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
            row.AccountNumber.Trim(),
            row.Description.Trim(),
            row.Credit?.ToString("0.00", CultureInfo.InvariantCulture),
            row.Debit?.ToString("0.00", CultureInfo.InvariantCulture));

        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(canonical));

        return Convert.ToHexString(hash);
    }
}
