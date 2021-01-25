using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace StudyHelper.Models
{
    public class HomeWorkContext
    {
        private IMongoDatabase Database;
        private IGridFSBucket GridFs;

        public HomeWorkContext()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;

            var connection = new MongoUrlBuilder(connectionString);

            MongoClient client = new MongoClient(connectionString);

            Database = client.GetDatabase(connection.DatabaseName);
            GridFs = new GridFSBucket(Database);
        }

        public IMongoCollection<HomeWork> HomeWorks => Database.GetCollection<HomeWork>("HomeWork");

        public async Task Add(HomeWork homeWork)
        {
            await HomeWorks.InsertOneAsync(homeWork);
        }

        public async Task RemoveByIndex(int index)
        {
            await HomeWorks.DeleteOneAsync(work => work.Id == index);
        }

        public Task<List<HomeWork>> GetHomeWorks()
        {
            return HomeWorks.Find(new BsonDocument()).ToListAsync();
        }

        public long GetSize()
        {
            var filter = Builders<HomeWork>.Filter.Where(homeWork => homeWork.SubjectName != "");
            return HomeWorks.Count(filter);
        }
    }
}