using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodMartMono.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]// dönecği veri türü
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
    }
}
