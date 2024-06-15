using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapiasassassaasasasasasasasasasasasasasasas"));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost",
                audience: "http://localhost",
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(20),
                signingCredentials: credentials
            );

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
        public string TokenCreateAdmin()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapiasassassaasasasasasasasasasasasasasasas");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"Visitor")
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: "http://localhost", 
                audience: "http://localhost", 
                notBefore: DateTime.Now, 
                expires: DateTime.Now.AddMinutes(30), 
                signingCredentials: credentials,
                claims: claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSecurityToken);
        }
    }
}
