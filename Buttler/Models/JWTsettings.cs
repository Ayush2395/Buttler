namespace Buttler.API.Models
{
    public class JWTsettings
    {
        public string Subject { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
