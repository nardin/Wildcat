using System.Configuration;
using MongoDB.Driver;

namespace Wildcat.DB.System
{
    class MongoDB
    {
        protected static MongoDatabase instance;

        private MongoDB() { }

        public static MongoDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    var con = new MongoConnectionStringBuilder(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);
                    var server = MongoServer.Create(con);
                    instance = server.GetDatabase(con.DatabaseName);

                }
                return instance;
            }
        }
    }
}
