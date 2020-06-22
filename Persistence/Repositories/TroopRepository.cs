using System.Collections.Generic;
using System.Linq;

using Models.Troops;

using Persistence.Database.Context;

namespace Persistence.Repositories
{
    internal class TroopRepository : ITroopRepository
    {
        private readonly ICookieDbContext _cookieDbContext;

        public TroopRepository(ICookieDbContext cookieDbContext)
        {
            _cookieDbContext = cookieDbContext;
        }

        public IEnumerable<ITroop> GetTroops()
        {
            return _cookieDbContext.TroopEntities.AsEnumerable();
        }
    }
}
