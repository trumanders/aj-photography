using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Contexts;

public class Context : DbContext
{
    public DbSet<Photo> Photo => Set<Photo>();
    
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Photo>()
            .Property(p => p.PhotoCategory)
            .HasConversion<string>();

        modelBuilder.Entity<Photo>()
            .Property(p => p.PageCategory)
            .HasConversion<string>();

        // Disable cascade delete here

        // Configure composite keys here

        // Seed data here        
    }
}
