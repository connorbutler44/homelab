using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Homelab.Data.Entities;
using Homelab.Domain;

namespace Homelab.Features.Finance.Importer;

public interface ICsvParser
{
    FinanceAccountProvider Provider { get; }

    Task<IReadOnlyList<FinanceTransaction>> ParseAsync(Stream file, Guid accountId);
}