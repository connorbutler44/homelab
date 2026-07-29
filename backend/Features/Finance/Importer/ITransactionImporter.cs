using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Homelab.Data.Entities;
using Homelab.Domain;

namespace Homelab.Features.Finance.Importer;

public interface ITransactionImporter
{
    Task<IReadOnlyList<FinanceTransaction>> ImportAsync(Stream file, FinanceAccountProvider provider);
}