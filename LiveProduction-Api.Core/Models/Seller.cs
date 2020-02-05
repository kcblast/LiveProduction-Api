using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LiveProduction_Api.Core.Models
{
   public class Seller: BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [DisplayName("Shop Name")]
        public string CompanyName { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [DisplayName("Contact Personnel")]
        public string ContactPersonnel { get; set; }
    }
}
