namespace LiveProduction_Api.Core.Models.Products
{
    public class Stock
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}