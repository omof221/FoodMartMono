using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodMartMono.Entities
{
    public class Discount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DiscountId { get; set; }
        public string DiscountTitle { get; set; }
        public string DiscountSubtitle { get; set; }
        public string DiscountDescription { get; set; }
        public string ImmageUrl { get; set; }
    }
}
