using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodMartMono.Entities
{
    public class Category
    {// bsonıd primary ker yapar
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string IconUrl { get; set; }
    }
}
