using LiveProduction_Api.Core.Helpers;
using LiveProduction_Api.Core.InterfaceServices;
using LiveProduction_Api.Core.Models;
using LiveProduction_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveProduction_Api.Domain
{
    public class UserService : IUserServices
    {
        private LiveProductionDbContext _context;
        private ILogger _logger;
        public UserService(LiveProductionDbContext context, ILogger logger )
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> Authenticate(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return false;
                // Check if username exists
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
                if (user == null)
                    return false;
                // Check if password is correct
                if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    return false;

                //authentication successful
                return true;
            }
            catch(Exception ex)
            {
                //Implement Logger
                
                _logger.LogError(ex.Message, ex.InnerException.Message, ex.StackTrace);

            }
            return false;
        }

        public async Task Delete(int Id)
        {
            try
            {
                var user = await _context.Users.FindAsync(Id);
                if (user !=null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.GetBaseException(), ex.InnerException.Message);
            }
        }

        public async Task<User> GetById(long Id)
        {
            try
            {
                return await _context.Users.FindAsync( Id);// What does FindAsync means?

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException.Message, ex.StackTrace);
            }
            return null;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException.Message, ex.StackTrace);
            }
            return null;
        }

        public async Task<User> GetUser_ByUsername(string username)
        {
            try
            {
                return await _context.Users.SingleOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower());
                    
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException.Message, ex.StackTrace);
            }
            return null;
        }

        public async Task<User> Register(User user, string password)
        {
            try
            {

            
            //Validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (await _context.Users.AnyAsync(x => x.UserName == user.UserName))
                throw new AppException("Username\"" + user.UserName + "," + "\" is already taken");

                byte[] passwordHash = null, passwordSalt = null;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return user;


            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException.Message, ex.StackTrace);
            }
            return null;
        }

        public async Task Update(User userParam, string password = null)
        {
            var user = await _context.Users.FindAsync(userParam.Id);
            try
            {
                if (user == null)
                    throw new AppException("User not found");

                //Update username if it has changed
                if(!string.IsNullOrWhiteSpace(userParam.UserName) && userParam.UserName != user.UserName)
                    {
                    //throw error if the new username is already taken

                    if (await _context.Users.AnyAsync(x => x.UserName == userParam.UserName))
                        throw new AppException("Username " + userParam.UserName + " is already taken");

                    user.UserName = userParam.UserName;
                    }
                // Update user properties if provided
                if (!string.IsNullOrWhiteSpace(password))
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash(password, out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                }

                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.GetBaseException(), ex.InnerException.Message);
            }
        }

        // Private helpers method
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                        return false;
                }
            }
            return true;
        }


    }
}
