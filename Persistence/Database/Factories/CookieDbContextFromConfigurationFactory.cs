using System.Collections.Generic;

using Microsoft.Extensions.Options;

using Persistence.Database.Context;
using Persistence.Database.Options;

namespace Persistence.Database.Factories
{
    internal class CookieDbContextFromConfigurationFactory : IDbContextFromConfigurationFactory<CookieDbContext>
    {
        private readonly DatabaseOptions _databaseOptions;
        private readonly IDictionary<DatabaseProvider, IDbContextFactory<CookieDbContext>> _dbContextFactories;

        public CookieDbContextFromConfigurationFactory(IOptions<DatabaseOptions> databaseOptions, 
            IDictionary<DatabaseProvider, IDbContextFactory<CookieDbContext>> dbContextFactories)
        {
            _databaseOptions = databaseOptions.Value;
            _dbContextFactories = dbContextFactories;
        }

        public CookieDbContext CreateDbContextFromConfiguration()
        {
            return _dbContextFactories[_databaseOptions.DatabaseProvider].CreateDbContext(_databaseOptions.ConnectionString);
        }
    }
}
