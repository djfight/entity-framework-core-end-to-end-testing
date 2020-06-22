using Microsoft.EntityFrameworkCore;

namespace Persistence.Database.Context
{
    internal class CookieDbContext : DbContext, ICookieDbContext
    {
        public CookieDbContext(DbContextOptions<CookieDbContext> options)
            : base(options)
        {
        }
    }
}
