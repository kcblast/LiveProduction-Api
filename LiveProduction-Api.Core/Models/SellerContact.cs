using System;
using System.Collections.Generic;
using System.Text;

namespace LiveProduction_Api.Core.Models
{
    public class SellerContact : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public Guid ReceipientId { get; set; }
    }
}
