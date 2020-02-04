using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveProduction_Api.Core.Models
{
    public class Contact : BaseEntity
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public Address Address { get; set; }
    }
}
