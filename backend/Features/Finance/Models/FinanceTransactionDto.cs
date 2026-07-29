using System;

namespace Homelab.Features.Finance.Models;

public class FinanceTransactionDto
{
    public Guid Id { get; set; }
    public Guid FinanceAccountId { get; set; }
    public FinanceAccountDto FinanceAccount { get; set; } = null!;
    public int Amount { get; set; }
}