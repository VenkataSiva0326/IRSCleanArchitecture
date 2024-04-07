using Microsoft.AspNetCore.Mvc;

namespace IRSCleanArchitecture.API.Extensions
{
    public class ContentTypeValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ContentTypeValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.HasFormContentType && context.Request.ContentType!=null && !context.Request.ContentType.Equals("application/json"))
            {
                context.Response.StatusCode = 415; // Unsupported Media Type
                await context.Response.WriteAsync("Unsupported Media Type: Only application/json is supported.");
                return;
            }

            await _next(context);
        }
    }

}
