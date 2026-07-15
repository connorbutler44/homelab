using System.Collections.Generic;
using System.Threading.Tasks;
using Homelab.Models;

namespace Homelab.Repositories;

public interface ITestRepository
{
    Task<List<TestModel>> GetAllAsync();

    Task<TestModel?> GetByIdAsync(int id);
}