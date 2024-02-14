using ClothingStore.Application.Service;
using ClothStoreApplication.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClothingStoreApplication.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(UserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            try
            {
                bool registrationResult = await _userService.AddAsync(userDto);

                if (registrationResult)
                {
                    return Ok("User registered successfully");
                }

                return BadRequest("User registration failed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            bool loginResult = await _userService.GetByUserNameAsync(userLoginDto);

            if (loginResult)
            {
                string token = CreateToken(userLoginDto);
                return Ok(token);
            }
            else
            {
                return BadRequest("Invalid username or password");
            }
        }

        private string CreateToken(UserLoginDto userLoginDto)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userLoginDto.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
