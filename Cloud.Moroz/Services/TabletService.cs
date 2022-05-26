using Cloud.Moroz.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Cloud.Moroz.Services
{
    public class TabletService : ITabletService
    {
        private readonly IMongoCollection<Tablet> _tablets;
        public TabletService(IDbClient dbClient)
        {
            _tablets = dbClient.GetTabletCollection();
        }

        public Tablet AddTablet(Tablet tablet)
        {
            _tablets.InsertOne(tablet);
            return tablet;
        }

        public void DeleteTablet(string id)
        {
            _tablets.DeleteOne(tablet => tablet.Id == id);
        }

        public Tablet GetTablet(string id)
        {
            return _tablets.Find(tablet => tablet.Id == id).First();
        }

        public List<Tablet> GetTablets()
        {
            return _tablets.Find(tablet => true).ToList();
        }

        public Tablet UpdateTablet(Tablet tablet)
        {
            GetTablet(tablet.Id);
            _tablets.ReplaceOne(b => b.Id == tablet.Id, tablet);
            return tablet;
        }
    }
}
