using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IRSCleanArchitecture.API.Extensions
{
    public class ContentTypeValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.HasFormContentType && context.HttpContext.Request.ContentType !=null)
            {
                if(!context.HttpContext.Request.ContentType.Equals("application/json"))
                {
                    context.HttpContext.Response.StatusCode = 415; // Unsupported Media Type
                    context.Result = new BadRequestObjectResult("Unsupported Media Type: Only application/json is supported.");
                }
            }
        }
    }

}
