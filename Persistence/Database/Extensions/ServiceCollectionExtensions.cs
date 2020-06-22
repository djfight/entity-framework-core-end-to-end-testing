using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Persistence.Database.Context;
using Persistence.Database.Factories;
using Persistence.Database.Options;

namespace Persistence.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddSingleton<InMemoryFactory>();
            services.AddSingleton<SqlServerFactory>();

            services.AddSingleton<IDbContextFromConfigurationFactory<CookieDbContext>, CookieDbContextFromConfigurationFactory>(serviceProvider =>
            {
                // resolve dependencies for db context from configuration factory
                var databaseOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>();
                var inMemoryFactory = serviceProvider.GetRequiredService<InMemoryFactory>();
                var sqlServerFactory = serviceProvider.GetRequiredService<SqlServerFactory>();

                // build dictionary for in memory and sql server factories
                var dbContextFactories = new Dictionary<DatabaseProvider, IDbContextFactory<CookieDbContext>>()
                {
                    { DatabaseProvider.InMemory, inMemoryFactory },
                    { DatabaseProvider.SqlServer, sqlServerFactory }
                };

                // create the db context factory
                return new CookieDbContextFromConfigurationFactory(databaseOptions, dbContextFactories);
            });

            services.AddScoped<ICookieDbContext, CookieDbContext>(serviceProvider =>
            {
                var dbContextFromConfigurationFactory = serviceProvider.GetRequiredService<IDbContextFromConfigurationFactory<CookieDbContext>>();

                return dbContextFromConfigurationFactory.CreateDbContextFromConfiguration();
            });
        }
    }
}
