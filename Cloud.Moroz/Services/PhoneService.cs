using Cloud.Moroz.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Cloud.Moroz.Services
{
    public class PhoneServices : IPhoneServices
    {
        private readonly IMongoCollection<Phone> _phones;
        public PhoneServices(IDbClient dbClient)
        {
            _phones = dbClient.GetPhoneCollection();
        }

        public Phone AddPhone(Phone phone)
        {
            _phones.InsertOne(phone);
            return phone;
        }

        public void DeletePhone(string id)
        {
            _phones.DeleteOne(phone => phone.Id == id);
        }

        public Phone GetPhone(string id)
        {
            return _phones.Find(phone => phone.Id == id).First();
        }

        public List<Phone> GetPhones()
        {
            return _phones.Find(phone => true).ToList();
        }

        public Phone UpdatePhone(Phone phone)
        {
            GetPhone(phone.Id);
            _phones.ReplaceOne(b => b.Id == phone.Id, phone);
            return phone;
        }
    }
}
