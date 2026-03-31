namespace TestWebAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY = "my-secret-api-key";

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-Api-Key", out var key) || key != API_KEY)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key missing or invalid");
                return;
            }

            await _next(context);
        }
    }
}
