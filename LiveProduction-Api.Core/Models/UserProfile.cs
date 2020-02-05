using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveProduction_Api.Core.Models
{
    public class UserProfile:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [StringLength(30)]
        public string Country { get; set; }
        public string ImageUrl { get; set; }
        public Utility.Gender Gender { get; set; }
        #region Relationships
        [ForeignKey("User")]
        public long UserID { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}