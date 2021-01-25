namespace StudyHelper.Models
{
    public class HomeWorkDatabaseSettings : IDatabaseSettings
    {
        public string HomeWorkCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string HomeWorkCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}