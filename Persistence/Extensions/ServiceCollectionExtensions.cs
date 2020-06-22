using Microsoft.Extensions.DependencyInjection;
using Persistence.Database.Extensions;
using Persistence.Repositories;

namespace Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDatabase();

            services.AddTransient<ITroopRepository, TroopRepository>();
        }
    }
}