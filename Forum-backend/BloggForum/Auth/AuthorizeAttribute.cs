namespace Forum.Auth;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Forum.Entities;
using Forum.Auth;
using Microsoft.AspNetCore.Http;



[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // skip authorization if action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        var loggedInUser = (User)context.HttpContext.Items["User"];

        if (loggedInUser == null)
        {
            context.Result = new JsonResult(new { message = "Auth failed " }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}