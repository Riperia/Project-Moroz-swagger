using Cloud.Moroz.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cloud.Moroz
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Phone> _phones;
        private readonly IMongoCollection<Tablet> _tablets;
        private readonly IMongoCollection<Computer> _computers;
        public DbClient(IOptions<ApplicationDbConfig> appDbConfig)
        {
            var client = new MongoClient(appDbConfig.Value.Connection_String);
            var database = client.GetDatabase(appDbConfig.Value.Database_Name);
            _phones = database.GetCollection<Phone>(appDbConfig.Value.Phones_Collection_name);
            _tablets = database.GetCollection<Tablet>(appDbConfig.Value.Tablets_Collection_name);
            _computers = database.GetCollection<Computer>(appDbConfig.Value.Computers_Collection_name);
        }
        public IMongoCollection<Phone> GetPhoneCollection()
        {
            return _phones;
        }
        public IMongoCollection<Tablet> GetTabletCollection()
        {
            return _tablets;
        }
        public IMongoCollection<Computer> GetComputerCollection()
        {
            return _computers;
        }
    }
}
