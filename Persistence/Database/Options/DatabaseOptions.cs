namespace Persistence.Database.Options
{
    public class DatabaseOptions
    {
        public const string Name = "DatabaseOptions";
        public string ConnectionString { get; set; }
        public DatabaseProvider DatabaseProvider { get; set; }
    }
}
