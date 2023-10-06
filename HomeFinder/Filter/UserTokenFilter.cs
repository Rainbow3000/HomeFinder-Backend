using HomeFinder.Core.Helper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinder.Filter
{
    public class UserTokenFilter:IActionFilter
    {
        private readonly IConfiguration _configuration;

        public UserTokenFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string token = new JwtValidateHelper(_configuration).TokenIsExist(context);
            string role = new JwtValidateHelper(_configuration).ValidateToken(context, token);
            if (role != "USER" || role != "ADMIN")
            {
                context.Result = new ObjectResult(new
                {
                    Code = StatusCodes.Status403Forbidden,
                    Message = "Account is not allowed"
                });
            }
        }
    }
}
