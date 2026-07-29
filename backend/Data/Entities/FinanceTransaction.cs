using System;

namespace Homelab.Data.Entities;

public class FinanceTransaction
{
    public Guid Id { get; set; }
    public Guid FinanceAccountId { get; set; }
    public FinanceAccount FinanceAccount { get; set; } = null!;
    public int Amount { get; set; }
}