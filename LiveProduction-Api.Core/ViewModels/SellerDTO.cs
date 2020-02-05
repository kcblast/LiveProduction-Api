using System;
using System.Collections.Generic;
using System.Text;

namespace LiveProduction_Api.Core.ViewModels
{
   public class SellerDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
        public string SellerName
        {
            get
            {
                return string.Concat(FirstName, " ", LastName);
            }
        }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ShopAddress { get; set; }
        public string CompanyName { get; set; }


    }
}
