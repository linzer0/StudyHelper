using System;
using System.IO;
using System.Web;
using System.Web.Helpers;

namespace StudyHelper.Utils
{
    public class DataBaseSettings
    {
        public static DatabaseConnection GetConnectionString()
        {
            var path = HttpContext.Current.Server.MapPath("~/appsetting.json");
            Console.WriteLine(path);
            return GetConnectionStringFromFile(path);
        }

        private static DatabaseConnection GetConnectionStringFromFile(string path)
        {
            DatabaseConnection databaseConnection = null;
            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    var data = streamReader.ReadToEnd();
                    databaseConnection = Json.Decode<DatabaseConnection>(data);
                }
            }

            return databaseConnection;
        }
    }
}