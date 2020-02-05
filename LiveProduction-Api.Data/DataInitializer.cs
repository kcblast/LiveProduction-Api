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
                EmailConfirmed = true,
                ConfirmationToken = "asfdagfegwrgsgfg",
                Roles = new List<UserRole>
                {
                    new UserRole
                    {
                        RoleID = (int)Utility.Roles.Admin,
                        UserID = 1
                    },
                    new UserRole
                    {
                        RoleID = (int)Utility.Roles.SuperAdmin,
                        UserID = 1
                    }
                },
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            context.AddRange(user);

            CreatePasswordHash("ABC12345", out passwordHash, out passwordSalt);

            User user2 = new User
            {

                UserName = "Kelechi",
                EmailAddress = "admin2@kelechi.com",
                ConfirmationToken = "asfdagfegwrgsgfg",
                EmailConfirmed = true,
                Roles = new List<UserRole>
                {
                    new UserRole
                    {
                        RoleID = (int)Utility.Roles.SuperAdmin,
                        UserID = 2
                    },
                    new UserRole
                    {
                        RoleID = (int)Utility.Roles.Admin,
                        UserID = 2
                    }
                },
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            context.AddRange(user2);

            CreatePasswordHash("ABC12345", out passwordHash, out passwordSalt);

            User user3 = new User
            {

                UserName = "UserKelechi",
                EmailAddress = "admin3@kelechi.com",
                ConfirmationToken = "asfdagfegwrgsgfg",
                EmailConfirmed = true,
                Roles = new List<UserRole>
                {
                    new UserRole
                    {
                        RoleID = (int)Utility.Roles.Buyer,
                        UserID = 3
                    },
                    
                },
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            context.AddRange(user3);

            CreatePasswordHash("ABC12345", out passwordHash, out passwordSalt);

            User user4 = new User
            {

                UserName = "4Kelechi",
                EmailAddress = "admin4@kelechi.com",
                ConfirmationToken = "asfdagfegwrgsgfg",
                EmailConfirmed = true,
                Roles = new List<UserRole>
                {
                    new UserRole
                    {
                        RoleID = (int)Utility.Roles.Seller,
                        UserID = 1
                    },
                   
                },
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            context.AddRange(user4);

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
