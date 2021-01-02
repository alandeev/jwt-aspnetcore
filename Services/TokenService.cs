using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using jwt_01.Models;
using Microsoft.IdentityModel.Tokens;

namespace jwt_01.Services
{
  public static class TokenService {
    public static string GenerateToken(User user){
      var tokenHandler = new JwtSecurityTokenHandler();

      var key = Encoding.ASCII.GetBytes(Settings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor {
        Subject = new ClaimsIdentity(new Claim[] {
          new Claim(ClaimTypes.Name, user.name.ToString()),
          new Claim(ClaimTypes.Role, user.role.ToString()),
          new Claim(ClaimTypes.NameIdentifier, user.id.ToString())
        }),
        Expires = DateTime.UtcNow.AddHours(2),
        SigningCredentials = new SigningCredentials(
          new SymmetricSecurityKey(key), 
          SecurityAlgorithms.HmacSha256Signature
        )
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}