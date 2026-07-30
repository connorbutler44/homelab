using System;
using CsvHelper.Configuration.Attributes;

namespace Homelab.Features.Finance.Importer.Providers.Ncsecu;

public class NcsecuTransactionRow
{
    public DateOnly Date { get; set; }

    [Name("Account Number")]
    public required string AccountNumber { get; set; }

    public decimal? Debit { get; set; }

    public decimal? Credit { get; set; }

    public required string Description { get; set; }
}
