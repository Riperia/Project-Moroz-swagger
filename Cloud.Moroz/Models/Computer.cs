using MongoDB.Bson.Serialization.Attributes;

namespace Cloud.Moroz.Models
{
    public class Computer
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
