using System;
using System.Collections.Generic;
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
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ContactPersonnel { get; set; }
    }
}
