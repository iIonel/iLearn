using ILearn.Domain.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ILearn.Domain.Enums;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace ILearn.Application.Helpers
{
    public class JwtService : IJwtService
    {
        public Task<string> CreateToken(int id, Roles role, IConfiguration configuration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            
            Console.WriteLine(role.ToString());
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),     
                new Claim(ClaimTypes.Role, role.ToString())   
            };

            var tokenDescriptor = new JwtSecurityToken(
              claims: claims,
              expires: DateTime.UtcNow.AddDays(1),
              signingCredentials: credentials
            );


            foreach (var claim in tokenDescriptor.Claims)
                Console.WriteLine(claim);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            Console.WriteLine("Token: " +jwt);

            return Task.FromResult(jwt);
        }
    }
}
