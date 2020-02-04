using LiveProduction_Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveProduction_Api.Data
{
   public class DataInitializer
    {
        public static void SeedData(LiveProductionDbContext context)
        {
            context.Database.EnsureCreated();

            //Create a super admin account
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash("ABC12345", out passwordHash, out passwordSalt);

            User user = new User
            {
                UserName = "AdminKelechi",
                EmailAddress = "admin@kelechi.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            context.AddRange(user);

        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash,
            out byte[] passwordSalt)
        {

            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
