using System;
using System.Collections.Generic;

namespace Homelab.Data.Entities;

public class FinanceAccount
{
    public Guid Id { get; set; }
    public required string Key { get; set; }
    public required string Name { get; set; }
    public required string AccountNumberLastFour { get; set; }
    public ICollection<FinanceTransaction> Transactions { get; set; } = [];
}