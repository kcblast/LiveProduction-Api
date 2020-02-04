namespace LiveProduction_Api.Core.ViewModels
{
    public class ConfirmEmailDTO
    {
        public string Token { get; set; }
        public long UserId { get; set; }
    }
}