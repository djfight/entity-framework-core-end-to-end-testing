using Microsoft.EntityFrameworkCore;

using Persistence.Database.Context;

namespace Persistence.Database.Factories
{
    internal class InMemoryFactory : IDbContextFactory<CookieDbContext>
    {
        private readonly string _connectionString;

        public InMemoryFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CookieDbContext CreateDbContext()
        {
            var cookieDbContextOptionsBuilder = new DbContextOptionsBuilder<CookieDbContext>();

            cookieDbContextOptionsBuilder.UseInMemoryDatabase(_connectionString);

            return new CookieDbContext(cookieDbContextOptionsBuilder.Options);
        }
    }
}