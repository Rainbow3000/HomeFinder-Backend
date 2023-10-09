
using HomeFinder.Core.Interface.Repository;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Core.Service;
using HomeFinder.Filter.Jwt;
using HomeFinder.Infrastructure.DataAccess;
using HomeFinder.Infrastructure.Repository;
using HomeFinder.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

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
                    return new BadRequestObjectResult(new 
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = errorsValue
                    });
                };
            });
         
            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();

            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<ICommentService, CommentService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IRoomService, RoomService>();


            builder.Services.AddScoped<IImageRepository, ImageRepository>();
            builder.Services.AddScoped<IImageService, ImageService>();


            builder.Services.AddDbContext<DatabaseContext>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<AdminTokenFilter>();
            builder.Services.AddScoped<UserTokenFilter>();


            var secretKey = builder.Configuration["Jwt:Key"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);


            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        
            app.UseMiddleware<ExceptionMiddleware>(); 
            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");
            app.UseAuthentication(); 
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}