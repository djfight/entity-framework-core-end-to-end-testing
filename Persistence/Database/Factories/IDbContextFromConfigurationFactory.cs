using Microsoft.EntityFrameworkCore;

namespace Persistence.Database.Factories
{
    internal interface IDbContextFromConfigurationFactory<out TDbContext> 
        where TDbContext : DbContext
    {
        TDbContext CreateDbContextFromConfiguration();
    }
}