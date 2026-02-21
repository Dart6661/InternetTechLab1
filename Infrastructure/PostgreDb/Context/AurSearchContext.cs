using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.PostgreDb.Context;

public class AurSearchContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AurPackage> Packages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AurPackage>(entity =>
        {
            entity.ToTable("packages");
            entity.HasKey(p => p.ID);
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.Version);
            entity.Property(p => p.URL);
            entity.Property(p => p.Description);
        });
    }
}