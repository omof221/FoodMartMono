namespace FoodMartMono.Dtos.ProductDto
{
    public class GetProductByIdDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImmageUrl { get; set; }
        public bool Status { get; set; }
        public int StockCount { get; set; }
        public string CategoryId { get; set; }

    }
}
