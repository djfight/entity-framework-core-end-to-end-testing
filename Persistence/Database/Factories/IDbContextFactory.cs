namespace Persistence.Database.Factories
{
    public interface IDbContextFactory<out TDbContext>
    {
        TDbContext CreateDbContext();
    }
}