using System;
using System.Collections.Generic;
using System.Text;

namespace LiveProduction_Api.Core.ViewModels
{
   public class ProductDTO
    {
        public int PropertyCount { get; set; }
        public Guid ID { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public string Description { get; set; }

    }
}
