using HomeFinder.Core.Exceptions;
using HomeFinder.Core.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeFinder.Filter
{
    public class AdminTokenFilter:IActionFilter
    {
        private readonly IConfiguration _configuration;

        public AdminTokenFilter(IConfiguration configuration)
        {
           _configuration = configuration;
        }

        public  void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public  void OnActionExecuting(ActionExecutingContext context)
        {
          string token = new JwtValidateHelper(_configuration).TokenIsExist(context);
          if(token == null)
            {
                context.Result = new ObjectResult(new
                {
                    Code = StatusCodes.Status401Unauthorized,
                    Message = "Token not exist"
                });
                return; 
            }
          string role = new JwtValidateHelper(_configuration).ValidateToken(context, token); 
          if(role != "ADMIN") {
                context.Result = new ObjectResult(new
                {
                    Code = StatusCodes.Status403Forbidden,
                    Message = "Account is not allowed"
                });
            }
        }
    }
}