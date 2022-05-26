using Cloud.Moroz.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Cloud.Moroz.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IMongoCollection<Computer> _computers;
        public ComputerService(IDbClient dbClient)
        {
            _computers = dbClient.GetComputerCollection();
        }
        public Computer AddComputer(Computer computer)
        {
            _computers.InsertOne(computer);
            return computer;
        }

        public void DeleteComputer(string id)
        {
            _computers.DeleteOne(computer => computer.Id == id);
        }

        public Computer GetComputer(string id)
        {
            return _computers.Find(computer => computer.Id == id).First();
        }

        public List<Computer> GetComputers()
        {
            return _computers.Find(computer => true).ToList();
        }

        public Computer UpdateComputer(Computer computer)
        {
            GetComputer(computer.Id);
            _computers.ReplaceOne(b => b.Id == computer.Id, computer);
            return computer;
        }
    }
}
