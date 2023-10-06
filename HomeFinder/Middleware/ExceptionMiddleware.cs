using HomeFinder.Core.Exceptions;
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


            if (exception is NotFoundException notFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(new BaseException()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = notFoundException.Message

                }.ToString() ?? "");
            }
            else if (exception is DuplicateException duplicateException)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsync(new BaseException()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = duplicateException.Message
                }.ToString() ?? "");
            }

            else if (exception is AuthException authException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(new BaseException()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = authException.Message
                }.ToString() ?? "");
            }
            else
            {
             context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(new BaseException()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = exception.GetType().Name + ": " + exception.Message
                }.ToString() ?? "");
            }
        }
    }
}
