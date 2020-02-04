namespace LiveProduction_Api.Core.Models
{
    public class UserProfile:BaseEntity
    {
        [StringLength(30)]
        public string Country { get; set; }
        public string ImageUrl { get; set; }
        public Gender Gender { get; set; }
        #region Relationships
        [Foreignkey("User")]
        public long UserID { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}