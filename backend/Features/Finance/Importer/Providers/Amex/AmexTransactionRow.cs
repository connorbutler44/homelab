using System;
using CsvHelper.Configuration.Attributes;

namespace Homelab.Features.Finance.Importer.Providers.Amex;

public class AmexTransactionRow
{
    public DateOnly Date { get; set; }

    public decimal Amount { get; set; }

    public required string Description { get; set; }

    [Name("Extended Details")]
    public required string ExtendedDetails { get; set; }

    public required string Reference { get; set; }
}
