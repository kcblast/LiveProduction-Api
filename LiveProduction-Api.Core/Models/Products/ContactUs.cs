using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveProduction_Api.Core.Models.Products
{
    public class ContactUs: BaseEntity
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Message { get; set; }
    }
}
