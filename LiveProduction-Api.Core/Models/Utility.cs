using System;
using System.Collections.Generic;
using System.Text;

namespace LiveProduction_Api.Core.Models
{
    public class Utility
    {
        public enum Gender
        {
            Male,
            Female
        }
        public enum ProductStatus
        {

            Pending,
            Awaiting,
            Approved
        }

        public enum Roles : int
        {
            Admin = 1,
            SuperAdmin = 2,
            Buyer = 3,
            Seller = 4
        }

        public class StatusMessage
        {
            public static string Ok = "Ok";
            public static string INVALID_USERNAME_AND_PASSWORD = "Invalid username and/or password";
            public static string CONFIRMATION_REQUIRED = "Your account is yet to be confirmed";
            public static string NOT_FOUND = "Record not found";
            public static string USER_EXIST = "Username already exist";
            public static string EMAIL_CONFIRMED = "Your email successfully confirmed";
            public static string PROCESS_FAILED = "Process failed to save";
            public static string VALID_USER = "Your account is valid";
            public static string PRODUCT_NOT_FOUND = "The product does not exist";
            public static string PROFILE_EXISTS = "Your profile already exists";
            public static string MESSAGE_SENT = "Your message was sent successfully";
        }
    }
}
