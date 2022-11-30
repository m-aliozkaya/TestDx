using Microsoft.EntityFrameworkCore;
using TestDx.Entities;

namespace TestDx.EntityFramework;

public class TestDxDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    
    public TestDxDbContext(DbContextOptions<TestDxDbContext> options) : base(options)
    {
        
    }
}