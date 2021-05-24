using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace APIContagem.Security
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations(TokenConfigurations tokenConfigurations)
        {
            Key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(tokenConfigurations.SecretJWTKey));

            SigningCredentials = new (
                Key, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}