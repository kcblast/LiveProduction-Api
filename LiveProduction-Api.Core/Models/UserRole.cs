using System.ComponentModel.DataAnnotations.Schema;

namespace LiveProduction_Api.Core.Models
{
    public class UserRole:BaseEntity
    {
        ///<summary>
        /// This defines the Role of the User Profile in the System. Users can have multiple roles
        ///</summary>
        [ForeignKey("User")]
        public long UserID { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Role")]
        public int RoleID { get; set; }
        //virtual => Laxy Load Roles
        public virtual Role  Role { get; set; }
    }
}