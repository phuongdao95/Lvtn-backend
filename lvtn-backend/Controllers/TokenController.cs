using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lvtn_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly EmsContext _context;

        public TokenController(IConfiguration config, EmsContext context)
        {
            _configuration = config;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(LoginDTO loginData)
        {
            if (loginData != null &&
                loginData.Username != null &&
                loginData.Password != null)
            {
                var user = getUserByUsernameAndPassword(loginData.Username, loginData.Password);

                if (user != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("user_id", user.Id.ToString()),
                        new Claim("name", user.Name),
                        new Claim("username", user.Username),
                    };



                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(60 * 4),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private User? getUserByUsernameAndPassword(
            string username,
            string password)
        {
            return _context.Users.FirstOrDefault((user) =>
                user.Username == username && user.Password == password);
        }
    }


}
