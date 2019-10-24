namespace MockAuthentication.Models
{
    public class AuthenticationResult
    {
        public bool IsAuthenticated { get; set; }
        public string AccessToken { get; set; }
        public string ErrorMessage { get; set; }
    }
}
