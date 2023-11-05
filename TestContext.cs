using Microsoft.EntityFrameworkCore;

namespace TptInheritanceTest;

public class TestContext : DbContext
{
    public DbSet<Base> Bases { get; set; }
    public DbSet<Derived> Deriveds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=testapp.db");
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.LogTo(s => System.Diagnostics.Debug.WriteLine(s), LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BaseConfiguration());
    }
}