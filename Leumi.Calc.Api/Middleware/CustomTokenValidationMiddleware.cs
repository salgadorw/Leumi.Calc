using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Leumi.Calc.Api.Middleware
{
    public class CustomTokenValidationMiddleware
    {

        private readonly RequestDelegate _next;

        public CustomTokenValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                await attachAccountToContext(context, token);
            }

            await _next(context);
        }

        private async Task attachAccountToContext(HttpContext context, string token)
        {
            try
            {
                var UserId = ValidateJwtToken(token);
                // on successful jwt validation attach UserId to context
                context.Items["UserId"] = UserId;
            }
            catch
            {
                // if jwt validation fails then do nothing 
            }
        }


        private int? ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("[Your secret key or password which will be used to sign and verify JWT TOKENS]");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var UserId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // if validation is successful then return UserId from JWT token 
                return UserId;
            }
            catch
            {
                // if validation fails then return null
                return null;
            }
        }
    }
}
