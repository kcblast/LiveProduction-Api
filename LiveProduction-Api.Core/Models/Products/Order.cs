namespace LiveProduction_Api.Core.Models.Products
{
    public class Order
    {
        public int Id { get; set; } 
        public string OrderRef { get; set; }    
        public string Address { get; set; } 
        public string Address { get; set; }
        public string City { get; set; }    
        public string PostCode { get; set; }   
        public ICollection<OrderProduct> OrderProducts { get; set;}
           
    }
}