using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace lvtn_backend.Middleware
{
    public class ClaimMiddleware
    {
        private readonly RequestDelegate _next;

        public ClaimMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            try
            {
                var tokenStartIndex = 7;

                var headerValue = httpContext.Request.Headers["Authorization"][0];
                var serializedToken = headerValue.Substring(tokenStartIndex);

                var jwtToken = new JwtSecurityTokenHandler()
                    .ReadJwtToken(serializedToken);

                var userIdClaim = jwtToken.Claims.First(claim => claim.Type == "user_id");
                var userId = userIdClaim.Value;
                var claims =
                    new List<Claim>
                    {
                        new Claim("user.create", "user.create"),
                        new Claim("user.update", "user.update"),
                        new Claim("user.update", "user.retrieve"),
                        new Claim("user.update", "user.delete"),
                    };

                httpContext.User.AddIdentity(new ClaimsIdentity(claims));
            }
            catch (Exception)
            {
                Console.WriteLine("JWT token is not valid, " +
                    "jump to controller if this middleware is added " +
                    "after authentication middleware.");
            }

            return _next(httpContext);
        }
    }

}
