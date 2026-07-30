using System;

namespace Homelab.Data.Entities;

public class FinanceTransaction
{
    public Guid Id { get; set; }
    public Guid FinanceAccountId { get; set; }
    public FinanceAccount FinanceAccount { get; set; } = null!;
    public required string InternalId { get; set; }
    public required string Description { get; set; }
    public required string ExtendedDetails { get; set; }
    public required decimal Amount { get; set; }
    public DateOnly Date { get; set; }
}