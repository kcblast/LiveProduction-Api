namespace LiveProduction_Api.Core.Models.Products
{
    public class OrderProduct
    {
     public int ProductId { get; set; }   
     public Product Product { get; set; }

     public int OrderId { get; set; }
     public Order Order { get; set; }
    }
}