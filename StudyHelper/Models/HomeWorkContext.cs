using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using StudyHelper.Utils;

namespace StudyHelper.Models
{
    public class HomeWorkContext
    {
        private IMongoDatabase Database;
        private IGridFSBucket GridFs;

        private DatabaseConnection DatabaseConnection;

        public HomeWorkContext()
        {
            DatabaseConnection = DataBaseSettings.GetConnectionString();

            var connection = new MongoUrlBuilder(DatabaseConnection.GetConnection());

            MongoClient client = new MongoClient(DatabaseConnection.GetConnection());

            Database = client.GetDatabase(connection.DatabaseName);
            GridFs = new GridFSBucket(Database);
        }

        public IMongoCollection<HomeWork> HomeWorks =>
            Database.GetCollection<HomeWork>(DatabaseConnection.CollectionName);

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
            if (HomeWorks == null)
            {
               Console.WriteLine("ITS NULL");
               return new HomeWorkContext().GetHomeWorks(); 
            }
            return HomeWorks.Find(new BsonDocument()).ToListAsync();
        }

        public long GetSize()
        {
            var filter = Builders<HomeWork>.Filter.Where(homeWork => homeWork.SubjectName != "");
            return HomeWorks.Count(filter);
        }
    }
}