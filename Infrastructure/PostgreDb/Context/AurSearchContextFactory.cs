using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.PostgreDb.Context;

/// <summary>
/// Factory for design-time initialization of the database context.
/// </summary>
public class AurSearchContextFactory : IDesignTimeDbContextFactory<AurSearchContext>
{
    public AurSearchContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AurSearchContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=aursearchdb;Username=dart");

        return new AurSearchContext(optionsBuilder.Options);
    }
}