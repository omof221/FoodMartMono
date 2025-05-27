using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodMartMono.Entities
{
    public class TrendProduct
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TrendProductId { get; set; }
        public string Title { get; set; }
    }
}
