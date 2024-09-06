using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.JsonWebTokens;
namespace JWT_Net8.Models.Infrastructire
{
    public sealed class TokenProvider(IConfiguration configuration)
    {


        public string Create(User user)
        {
            string secretKey = configuration["jwt:secretKey"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials=new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var tokenDescrior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, user.Email.ToString()),
                    new Claim("UserVerified",true.ToString()),
                    // If you want to assign the role then use the below line of code
                    new Claim(ClaimTypes.Role,"Admin")
                    ]),
                 Expires=DateTime.UtcNow.AddMinutes(3),
                 SigningCredentials = credentials,
                 Issuer= configuration["jwt:Issure"],
                 Audience= configuration["jwt:Audience"]
            };

            var handler = new JsonWebTokenHandler();

            string token = handler.CreateToken(tokenDescrior);

            return token;
        }
    }
}
