using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Persistence.Database.Context;
using Persistence.Database.Options;

namespace Persistence.Database.Factories
{
    internal class DbContextFromConfigurationFactory
    {
        private readonly IDictionary<DatabaseProvider, IDbContextFactory<CookieDbContext>> _dbContextFactories;
        private readonly DatabaseOptions _databaseOptions;

        public DbContextFromConfigurationFactory(IOptions<DatabaseOptions> databaseOptions, IDictionary<DatabaseProvider, IDbContextFactory<CookieDbContext>> dbContextFactories)
        {
            _dbContextFactories = dbContextFactories;
            _databaseOptions = databaseOptions.Value;
        }

        public CookieDbContext CreateCookieDbContextFromConfiguration()
        {
            return _dbContextFactories[_databaseOptions.DatabaseProvider].CreateDbContext();
        }
    }
}
