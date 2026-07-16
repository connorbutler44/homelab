using Microsoft.EntityFrameworkCore;
using Homelab.Domain;

namespace Homelab.Data;

public class AppDbContext : DbContext
{
    public DbSet<TestModel> TestModels => Set<TestModel>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}