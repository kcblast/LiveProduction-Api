using System;
using System.Collections.Generic;
using System.Text;
using static LiveProduction_Api.Core.Models.Utility;

namespace LiveProduction_Api.Core.Models.Products
{
   public class Product: BaseEntity
    {
        public ProductStatus Status { get; set; }
        public string Productname { get; set; }
        public decimal Price { get; set; }
        public string Productdescription { get; set; }
        public string Productvalue { get; set; }
        public int ProductCode { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
