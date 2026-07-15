using System.Collections.Generic;
using System.Threading.Tasks;
using Homelab.Data;
using Homelab.Models;
using Microsoft.EntityFrameworkCore;

namespace Homelab.Repositories;

public class TestRepository : ITestRepository
{
    private readonly AppDbContext _context;

    public TestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TestModel>> GetAllAsync()
    {
        return await _context.TestModels.ToListAsync();
    }

    public async Task<TestModel?> GetByIdAsync(int id)
    {
        return await _context.TestModels.FirstOrDefaultAsync(x => x.Id == id);
    }
}