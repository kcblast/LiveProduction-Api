using LiveProduction_Api.Core.InterfaceServices;
using LiveProduction_Api.Core.Models;
using LiveProduction_Api.Core.Models.Products;
using LiveProduction_Api.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LiveProduction_Api.Domain
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly LiveProductionDbContext _liveProductionContext;

        public EmailService(IConfiguration configuration, LiveProductionDbContext datatContext)
        {
            _configuration = configuration;
            _liveProductionContext = datatContext;
        }
        public void ContactAgent(SellerContact contact, string receipient)
        {
            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            values.Add("username", receipient);
            values.Add("api_key", _configuration["Email:api_key"]);
            values.Add("from", contact.Email);
            values.Add("from_name", contact.Name);
            values.Add("body_html", contact.Message);
            values.Add("to", receipient);
            client.UploadValuesAsync(new Uri("https://api.elasticemail.com/mailer/send"), values);
        }

        public void ContactUs(ContactUs contactUs)
        {
            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            values.Add("username",_configuration["Email:ContactEmail"]);
            values.Add("api_key", _configuration["Email:api_key"]);
            values.Add("from", contactUs.Email);
            values.Add("from_name", contactUs.Name);
            values.Add("body_html", contactUs.Message);
            values.Add("to", _configuration["Email:ContactEmail"]);
            client.UploadValuesAsync(new Uri("https://api.elasticemail.com/mailer/send"), values);
        }

        public void ProductMessage(Product product, string emailFor = "Verification")
        {
            try
            {
                string body = "";
                string subject = "";
                if (emailFor == "ApprovedProperty")
                {
                    body = string.Format(_configuration.GetValue<string>("ApprovedProductMessage"),
                        _configuration.GetValue<string>("ServerUr1"), product.ProductCode);
                    subject = "Invalid Listing";
                }

                WebClient client = new WebClient();
                NameValueCollection values = new NameValueCollection();
                values.Add("username", _configuration["Email:Email"]);
                values.Add("api_key", _configuration["Email:api_key"]);
                values.Add("from", _configuration["Email:Email"]);
                values.Add("subject", subject);
                values.Add("body_html", body);
                values.Add("to", product.UserProfile.FirstName);
                client.UploadValuesAsync(new Uri("https://api.elasticemail.com/mailer/send"), values);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public async Task SendEmail(string email, string subject, string body)
        {
            using (var client = new SmtpClient())
            {
                client.Host = _configuration["Email:Email"];
                client.Port = int.Parse(_configuration["Email:Port"]);
                client.EnableSsl = true;

                var credential = new NetworkCredential
                {
                    UserName = _configuration["Email:Email"],
                    Password = _configuration["Email:Password"]
                };
                client.Credentials = credential;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(email));
                    emailMessage.From = new MailAddress(_configuration["Email:Email"]);
                    emailMessage.Subject = subject;
                    emailMessage.Body = body;
                    emailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                    emailMessage.SubjectEncoding = System.Text.Encoding.Default;
                    emailMessage.IsBodyHtml = true;
                    client.Send(emailMessage);
                }
            }
            await Task.CompletedTask;
        }

        public void WelcomeNewUser(User user, string emailFor = "Verification")
        {
           try
            {
                string body = "";
                string subject = "";
                if (emailFor == "Verification")
                {
                    body = string.Format(_configuration.GetValue<string>("WelcomeNewUserMessage"),
                    _configuration.GetValue<string>("ServerUrl"), user.ConfirmationToken);
                    subject = "Welcome to Liveproduction";
                }
                else if(emailFor == "ResetPassword")
                {
                    body = string.Format(_configuration.GetValue<string>("ResetUserPasswordMessage"),
                        _configuration.GetValue<string>("ServerUrl"), user.PasswordResetCode);
                }

                WebClient client = new WebClient();
                NameValueCollection values = new NameValueCollection();
                values.Add("username", _configuration["Email:Email"]);
                values.Add("api_key", _configuration["Email:api_key"]);
                values.Add("from", _configuration["Email:Email"]);
                values.Add("from_name", _configuration["Email:from_name"]);
                values.Add("subject", subject);
                values.Add("body_html", body);
                values.Add("to", user.UserName);
                client.UploadValuesAsync(new Uri("https://api.elasticemail.com/mailer/send"), values);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
