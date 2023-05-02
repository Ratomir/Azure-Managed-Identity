using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;
public class StartDbContext : DbContext
{
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProductEntity> Products { get; set; }

    public StartDbContext(string connectionString) : base(GetOptions(connectionString))
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { }

    private static DbContextOptions GetOptions(string connectionString)
    {
        return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
    }
}
