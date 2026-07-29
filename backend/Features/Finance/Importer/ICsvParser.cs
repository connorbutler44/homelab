using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Homelab.Data.Entities;
using Homelab.Features.Finance.Models;

namespace Homelab.Features.Finance.Importer;

public interface ICsvParser
{
    FinanceAccount Account { get; }

    Task<IReadOnlyList<FinanceTransaction>> ParseAsync(Stream file);
}