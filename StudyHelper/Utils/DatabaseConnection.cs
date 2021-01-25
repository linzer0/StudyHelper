namespace StudyHelper.Utils
{
    public class DatabaseConnection
    {
        public string ConnectionString { get; set; }
        public string CollectionName { get; set; }
        public string DatabaseName { get; set; }

        public string GetConnection() => ConnectionString + "/" + DatabaseName;
    }
}