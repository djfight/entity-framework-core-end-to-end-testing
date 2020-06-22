using Microsoft.EntityFrameworkCore;

using Persistence.Database.Context;

namespace Persistence.Database.Factories
{
    internal class SqlServerFactory : IDbContextFactory<CookieDbContext>
    {
        private readonly string _connectionString;

        public SqlServerFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CookieDbContext CreateDbContext()
        {
            var cookieDbContextOptionsBuilder = new DbContextOptionsBuilder<CookieDbContext>();

            cookieDbContextOptionsBuilder.UseSqlServer(_connectionString);

            return new CookieDbContext(cookieDbContextOptionsBuilder.Options);
        }
    }
}
