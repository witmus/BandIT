using BandIT.Data;
using BandIT.Data.DAL;
using BandIT.Data.DAL.Abstraction;
using BandIT.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace BandIT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("bandit");
            builder.Services
                .AddDbContext<ApplicationDbContext>(options =>
                    options
                    .UseLazyLoadingProxies()
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        AudienceValidator = null,
                        ValidIssuer = configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                    };
                });

            builder.Services
                .Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequiredUniqueChars = 1;
                });

            var corsPolicy = "Default";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                        name: corsPolicy,
                        builder =>
                        {
                            builder
                                .WithOrigins()
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .SetIsOriginAllowed(config => true)
                                .AllowCredentials()
                                .Build();
                        }
                    );
            });

            // Add services to the container.
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            builder.Services.AddTransient<IBudgetRepository, BudgetRepository>();
            builder.Services.AddTransient<IContactRepository, ContactRepository>();
            builder.Services.AddTransient<IGearRepository, GearRepository>();
            builder.Services.AddTransient<IEventRepository, EventRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "BandIT", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>().ToList()
                    }
                });
            });

            var app = builder.Build();

            app.UseCors(corsPolicy);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}