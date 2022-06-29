using Leumi.Calc.Application.Services.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Leumi.Calc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        /// <summary>
        /// AuthController Initialization
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="cacheService"></param>
        public AuthController(IConfiguration config)
        {
            this._configuration = config;
        }

        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="email">Sign in user</param>
        /// <response code="200">Sign in user successfully</response>
        /// <response code="400">Sign in object missing or invalid</response>
        /// <response code="401">Bad credentials or user unauthorized</response>
        /// <response code="403">User email does not exists</response>
        [HttpPost]
        [Route("/auth")]
        
        [SwaggerOperation("GenerateToken")]
        [SwaggerResponse(statusCode: 200, type: typeof(string), description: "JASON Web Token generated for user")]
        public virtual async Task<IActionResult> GenerateToken([FromBody] LoginDTO login)
        {

            var claims = new[]
                    {
                        new Claim("Email", login.UserName),
                        new Claim(ClaimTypes.NameIdentifier, login.UserName)
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(tokenAsString);
        }
    }
}
