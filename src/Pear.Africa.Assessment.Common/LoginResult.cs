namespace Pear.Africa.Assessment.Common.Identity.Account
{
    public class LoginResult
    {
        public string UserName { get; set; }
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
