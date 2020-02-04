using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveProduction_Api.Core.Models
{
   public class Address : BaseEntity
    {
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("House Number")]
        public string ShopNo { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Street Name")]
        public string ShopStreet { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string LGA { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string State { get; set; }
    }
}
