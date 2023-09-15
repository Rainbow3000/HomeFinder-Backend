using HomeFinder.Core.Exception;
using HomeFinder.Core.Interface.Repository;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Core.Service;
using HomeFinder.Infrastructure.DataAccess;
using HomeFinder.Infrastructure.Repository;
using HomeFinder.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HomeFinder
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Custom error bad request
            builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var keys = actionContext.ModelState.Keys;
                    List<object> errorsValue = new List<object>();
                    var modelError = actionContext.ModelState.Values.SelectMany(model => model.Errors);
                    var errors = modelError.ToList().Select(err => err.ErrorMessage);
                    int index = 0;
                    errors.ToList().ForEach(item =>
                    {
                        Dictionary<string, object> values = new Dictionary<string, object>();
                        values.Add(keys.ToList()[index], item);
                        errorsValue.Add(values);
                        index++;
                    });
                    return new BadRequestObjectResult(new BaseException
                    {
                        ErrorCode = (int)HttpStatusCode.BadRequest,
                        DevMsg = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.BadRequest),
                        UserMsg = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.BadRequest),
                        TraceId = "",
                        MoreInfo = "",
                        ErrorMsgs = errorsValue

                    });
                };
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddDbContext<DatabaseContext>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>(); 
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}