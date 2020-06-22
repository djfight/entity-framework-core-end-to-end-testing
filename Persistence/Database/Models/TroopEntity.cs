using Models.Troops;

namespace Persistence.Database.Models
{
    internal class TroopEntity : ITroop
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
