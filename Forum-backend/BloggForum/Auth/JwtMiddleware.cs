using Forum.Services;
using Microsoft.AspNetCore.Http;
namespace Forum.Auth
{
    public class JwtMiddleware
    {
        private RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var loginToken = context.Request.Headers["Authorization"].SingleOrDefault()?.Split(" ").Last();
            var loggedInUserId = jwtUtils.ValidateToken(loginToken);

            if (loggedInUserId != null)
            {
                // attach user to context on successful jwt validation
                context.Items.Add("User", userService.GetUserById(loggedInUserId.Value));
            }

            await _next(context);
        }
    }
}
