using Microsoft.EntityFrameworkCore;

using Persistence.Database.Context;

namespace Persistence.Database.Factories
{
    internal class SqlServerFactory : IDbContextFactory<CookieDbContext>
    {
        public CookieDbContext CreateDbContext(string connectionString)
        {
            var cookieDbContextOptionsBuilder = new DbContextOptionsBuilder<CookieDbContext>();

            cookieDbContextOptionsBuilder.UseSqlServer(connectionString);

            return new CookieDbContext(cookieDbContextOptionsBuilder.Options);
        }
    }
}
