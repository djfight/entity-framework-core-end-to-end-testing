using Microsoft.EntityFrameworkCore;

using Persistence.Database.Context;
using Persistence.Database.Models;

namespace Persistence.Database.Factories
{
    internal class InMemoryFactory : IDbContextFactory<CookieDbContext>
    {
        private bool _inMemoryEntitiesLoaded;

        public InMemoryFactory()
        {
            _inMemoryEntitiesLoaded = false;
        }

        public CookieDbContext CreateDbContext(string connectionString)
        {
            var cookieDbContextOptionsBuilder = new DbContextOptionsBuilder<CookieDbContext>();

            cookieDbContextOptionsBuilder.UseInMemoryDatabase(connectionString);

            var inMemoryCookieDbContext = new CookieDbContext(cookieDbContextOptionsBuilder.Options);

            if (!_inMemoryEntitiesLoaded)
            {
                LoadTemporaryDatabase(inMemoryCookieDbContext);
            }

            return inMemoryCookieDbContext;
        }

        private void LoadTemporaryDatabase(CookieDbContext cookieDbContext)
        {
            cookieDbContext.TroopEntities.AddRange(
                new TroopEntity()
                {
                    Id = 1,
                    Name = "Troop1"
                },
                new TroopEntity()
                {
                    Id = 2,
                    Name = "Troop2"
                },
                new TroopEntity()
                {
                    Id = 3,
                    Name = "Troop3"
                }
            );

            cookieDbContext.SaveChanges();

            _inMemoryEntitiesLoaded = true;
        }
    }
}