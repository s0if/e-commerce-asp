
using E_commerce_core.Interface;
using E_commerce_core.Models;
using E_commerce_Infrastructure.Data;
using E_commerce_Infrastructure.Repository;
using E_commerce_Infrastructure.Service;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using testAPI_crud.Model;

namespace E_commerce_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections"));
            });
            builder.Services.AddIdentity<Users, IdentityRole<int>>(options =>
            {
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
                //options.SignIn.RequireConfirmedPhoneNumber = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
            builder.Services.AddControllers();
            //builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWorkRepository>();

            builder.Services.AddCors(
                option =>
                {
                    option.AddPolicy("AccessAll",
                        build => build.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
                });

            var config = TypeAdapterConfig.GlobalSettings;
            builder.Services.AddSingleton(config);
            builder.Host.UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration);
            });
            builder.Services.AddScoped<AuthServices>();
            builder.Services.AddAuthentication(
             options =>
             {
                 options.DefaultAuthenticateScheme = "Bearer";
                 options.DefaultChallengeScheme = "Bearer";
             }
             ).AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new
                Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     //from model AuthServices
                     ValidIssuer = "project Saif",
                     ValidAudience = "project",
                     ValidateLifetime = true,
                     IssuerSigningKey = new
                SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("jwt")["secretkey"
                ])
                )
                 };
             }
            );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AccessAll");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
