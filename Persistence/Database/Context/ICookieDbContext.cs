using Microsoft.EntityFrameworkCore;

using Persistence.Database.Models;

namespace Persistence.Database.Context
{
    internal interface ICookieDbContext
    {
        DbSet<TroopEntity> TroopEntities { get; }
    }
}