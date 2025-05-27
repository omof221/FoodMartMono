using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Data;

namespace FoodMartMono.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImmageUrl { get; set; }
        public bool Status { get; set; }
        public int StockCount { get; set; }
        public string CategoryId { get; set; }
    }
}
