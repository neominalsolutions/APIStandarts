using APIStandarts.Infrastructure.JWT;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace APIStandarts.Core.JWT
{
    public class JwtTokenService : IJwtTokenService
  {
    private const double EXPIRE_HOURS = 1.0;

    // 1 saatlik access token üreten servis
    public TokenDto CreateAccessToken(ClaimsIdentity identity)
    {
      var key = Encoding.ASCII.GetBytes(JWTSettings.SecretKey);
      var tokenHandler = new JwtSecurityTokenHandler();
      var descriptor = new SecurityTokenDescriptor
      {
        Subject = identity,
        Expires = DateTime.UtcNow.AddHours(EXPIRE_HOURS),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
      };
      var token = tokenHandler.CreateToken(descriptor);
      var accessToken = tokenHandler.WriteToken(token);


      return new TokenDto
      {
        AccessToken = accessToken,
        TokenType = "bearer"
      };
    }
  }
}
