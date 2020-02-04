using System;
using System.Collections.Generic;
using System.Text;

namespace LiveProduction_Api.Core.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public bool EmailConfirmed { get; set; }
        public Guid EmailActivationToken { get; set; } = Guid.NewGuid();
        public DateTime? LastLoginDate { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<UserRole> Roles { get; set; }  = new List<UserRole>();
    }
}
