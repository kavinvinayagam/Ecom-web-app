using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestWebAPI.Filters
{
    public class AuthorizationFilter:Attribute, IAuthorizationFilter
    {
        private const string API_KEY_HEADER_NAME = "x-api-key";
        private const string API_KEY = "my-secret-api-key";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(! context.HttpContext.Request.Headers.TryGetValue(API_KEY_HEADER_NAME, out var extractedApiKey) || !string.Equals(extractedApiKey, API_KEY, StringComparison.Ordinal))
            {
                context.Result = new UnauthorizedObjectResult("API Key is missing");
                return;
            }
        }
    }
}
