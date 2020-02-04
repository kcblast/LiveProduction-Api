namespace LiveProduction_Api.Core.Models
{
    public class Mail
    {
        [Required(ErrorMessage = "Email receiver's address is compulsory")]
        public string To { get; set; }
        [Required(ErrorMessage = "Email title is compulsory")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Email body is compulsory")]
        public string Message { get; set; }
    }
}