using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Homelab.Data.Entities;

namespace Homelab.Features.Finance.Importer;

public interface ITransactionImporter
{
    FinanceAccount Account { get; }

    Task<IReadOnlyList<FinanceTransaction>> ImportAsync(Stream file);
}