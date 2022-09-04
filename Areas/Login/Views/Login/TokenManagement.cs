using System.IdentityModel.Tokens.Jwt;

namespace AuthorizationMVC.Views.Login
{
    public class TokenManagement
    {
        public string Issuer;
        public string Audience;

        public char[] Secret { get; set; }
    }
}