using Services.Contracts;
using Services.Services;
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

        public Task Invoke(HttpContext httpContext, IPermissionService permissionService, 
            IdentityService identityService)
        {
            try
            {
                var tokenStartIndex = 7;

                var headerValue = httpContext.Request.Headers["Authorization"][0];
                var serializedToken = headerValue.Substring(tokenStartIndex);

                var jwtToken = new JwtSecurityTokenHandler()
                    .ReadJwtToken(serializedToken);

                var userIdClaim = jwtToken.Claims.First(claim => claim.Type == "user_id");
                var userUsernameClaim = jwtToken.Claims.First(claim => claim.Type == "username");
                var userNameClaim = jwtToken.Claims.First(claim => claim.Type == "user_name");
                var userId = int.Parse(userIdClaim.Value);
                var permissions = permissionService.GetPermissionsOfUser(userId);

                var permissionClaims = permissions.Select((permission) =>
                    new Claim(permission.Name, permission.Name))
                        .ToList();

                identityService.Id = userId;
                identityService.Username = userUsernameClaim.Value;
                identityService.Name = userNameClaim.Value;

                httpContext.User.AddIdentity(new ClaimsIdentity(permissionClaims));
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
