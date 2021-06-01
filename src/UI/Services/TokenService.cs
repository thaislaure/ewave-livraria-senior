using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UI.Services
{
    public class TokenService
    {

        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public dynamic GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("Jwt").GetValue<string>("SecretKey"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName .ToString()),
                    new Claim(ClaimTypes.Role, user.Perfil.ToString()),
                    new Claim(ClaimTypes.Sid, user.UserId .ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return new
            {
                tokenDescriptor.Expires,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = Guid.NewGuid().ToString().ToLower()
            };
        }
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Perfil { get; set; }
    }
}
