using Microsoft.EntityFrameworkCore;

using Persistence.Database.Models;

namespace Persistence.Database.Context
{
    internal class CookieDbContext : DbContext, ICookieDbContext
    {
        public DbSet<TroopEntity> TroopEntities { get; set; }

        public CookieDbContext(DbContextOptions<CookieDbContext> options)
            : base(options)
        {
        }
    }
}
