using LiveProduction_Api.Core.Models;
using LiveProduction_Api.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveProduction_Api.Core.InterfaceServices
{
   public interface IEmailService
    {
        Task SendEmail(string email, string subject, string body);

        void WelcomeNewUser(User user, string emailFor = "Verification");
        void ContactUs(ContactUs contactUs);
        void ContactAgent(SellerContact contact, string receipient);
        void ProductMessage(Product product, string emailFor = "Verification";)
    }
}
