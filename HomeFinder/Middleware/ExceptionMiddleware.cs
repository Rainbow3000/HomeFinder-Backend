using System.Net;
using System.Text.Json;

namespace HomeFinder.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


            

            var errorResponse = new
            {
                Message = exception.Message,
                ExceptionMessage = exception.Message,
            };      
            var jsonErrorResponse = JsonSerializer.Serialize(errorResponse);

            await context.Response.WriteAsync(jsonErrorResponse);
        }
    }
}
