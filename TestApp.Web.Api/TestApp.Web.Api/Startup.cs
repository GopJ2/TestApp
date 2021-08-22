using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using TestApp.Data;
using TestApp.Data.DataAccess;
using TestApp.Dto.Config;
using TestApp.Services.Auth;
using TestApp.Services.Tests;
using TestApp.Web.Api.Validators;

namespace TestApp.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connectionString = Configuration.GetConnectionString("Database");

            services.AddScoped(c => new GlobalDataAccess(connectionString));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITestService, TestsService>();
            services.AddScoped<ITestQuestionService, TestQuestionService>();

            ConfigureJwtBearer(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(option =>
                option.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
            );
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void ConfigureJwtBearer(IServiceCollection services)
        {
            services.AddScoped<UserJwtValidator>();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = JwtConfig.Issuer,
                        ValidateAudience = true,
                        ValidAudience = JwtConfig.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(JwtConfig.GetSymmetricKey()),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                    options.EventsType = typeof(UserJwtValidator);
                });
        }
    }
}