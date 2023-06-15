using APIStandarts.Core.JWT;
using APIStandarts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace WebApiLab.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly IJwtTokenService _tokenService;

        public TokensController(IJwtTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        // attributed based routing feature
        [HttpPost("token")]
        public IActionResult CreateToken([FromBody] LoginDto loginDto)
        {


            if(loginDto.Email == "test@test.com" && loginDto.Password == "123456")
            {
                var identity = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, loginDto.Email),
                    //new Claim(ClaimTypes.Role, "Admin"),
                    new Claim("UserId",Guid.NewGuid().ToString())
            });


                var token = _tokenService.CreateAccessToken(identity);

                return Ok(token);

            }

            return Unauthorized();

        }
    }
}
