using System.Collections.Generic;

using Models.Troops;

namespace Persistence.Repositories
{
    public interface ITroopRepository
    {
        IEnumerable<ITroop> GetTroops();
    }
}