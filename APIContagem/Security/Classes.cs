using Microsoft.AspNetCore.Identity;

namespace APIContagem.Security
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class AccessCredentials
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string GrantType { get; set; }
    }

    public class TokenConfigurations
    {
        public string AccessRole { get; set; }
        public string SecretJWTKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
        public int FinalExpiration { get; set; }
    }

    public class Token
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }
    }
 
    public class RefreshTokenData
    {
        public string RefreshToken { get; set; }
        public string UserID { get; set; }
    }
}