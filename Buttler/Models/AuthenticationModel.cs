namespace Buttler.API.Models
{
    public class AuthenticationModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public string Email { get; set; }
    }
}
