using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Experiment5.Filters;

namespace Experiment5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Custom Exception Filter
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            });

            // Enable CORS (Allow All)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            // JWT Setup
            var securityKey = "mysuperdupersecret";
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "mySystem",
                    ValidAudience = "myUsers",
                    IssuerSigningKey = symmetricSecurityKey
                };
            });

            builder.Services.AddAuthorization();

            // Swagger setup with JWT support
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger Demo",
                    Version = "v1",
                    Description = "JWT Authentication Demo",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "John Doe",
                        Email = "john@xyzmail.com",
                        Url = new Uri("https://www.example.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License Terms",
                        Url = new Uri("https://www.example.com")
                    }
                });

                // Add JWT Bearer token support in Swagger UI
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token.\r\n\r\nExample: \"Bearer abcdefgh123456\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            var app = builder.Build();

            // Enable Swagger UI
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");          
            app.UseAuthentication();          
            app.UseAuthorization();           

            app.MapControllers();

            app.Run();
        }
    }
}
