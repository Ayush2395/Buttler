namespace Buttler.API.Models
{
    public class AuthenticationModel
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
