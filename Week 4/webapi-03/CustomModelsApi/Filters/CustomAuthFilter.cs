using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomModelsApi.Filters
{
    /// <summary>
    /// Custom Authorization Filter as per requirements
    /// Intercepts incoming requests to check for Authorization header with Bearer token
    /// </summary>
    public class CustomAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Check if Authorization header exists
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
                return;
            }

            // Get Authorization header value
            var authHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

            // Check if the header contains 'Bearer'
            if (string.IsNullOrEmpty(authHeader) || !authHeader.Contains("Bearer"))
            {
                context.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
                return;
            }

            // If we reach here, the authorization is valid
            base.OnActionExecuting(context);
        }
    }
}
