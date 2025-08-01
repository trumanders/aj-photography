using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Contexts;

public class Context : DbContext
{
    public DbSet<HomePagePhoto> HomePagesPhoto => Set<HomePagePhoto>();
    
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Store Category as string
        modelBuilder.Entity<HomePagePhoto>()
            .Property(p => p.Category)
            .HasConversion<string>();

        // Disable cascade delete here

        // Configure composite keys here

        // Seed data here        
    }
}
