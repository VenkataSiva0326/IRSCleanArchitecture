namespace IRSCleanArchitecture.API.Extensions
{
    // Extension method used to add the middleware to the HTTP request pipeline
    public static class ContentTypeValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseContentTypeValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContentTypeValidationMiddleware>();
        }
    }
}
