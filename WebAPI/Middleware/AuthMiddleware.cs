using System.Text;

namespace WebAPI.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public AuthMiddleware(RequestDelegate next)
        {
            this._requestDelegate = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Autorization"))
            {
                context = await CreateUnauthorizedHeader(context);
                return;
            }

            string authHeader = context.Request.Headers["Authorization"].ToString();
            // TODO: implement auth middleware

        }

        private async Task<HttpContext> CreateUnauthorizedHeader(HttpContext context)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized access");
            return context;
        }


    }
}
