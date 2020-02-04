using LiveProduction_Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveProduction_Api.Core.InterfaceServices
{
    public interface IUserServices
    {
        Task<bool> Authenticate(string username, string password);
        Task<User> GetById(long Id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> Register(User user, string password);
        Task Update(User user, string password = null);
        Task<User> GetUser_ByUsername(string username);
        Task Delete(int Id);
    }
}
