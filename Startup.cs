using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ToDoAPI.Application;
using ToDoAPI.Infrastructure;

namespace ToDoAPI
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
            services.AddInfrastructureServices();

            services.AddApplicationServices();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearerOption =>
            {
                bearerOption.Audience = "vn8tujv2rd0f38i1q0s918afb";
                bearerOption.Authority = "https://mock-user-pool-domain.auth.us-east-1.amazoncognito.com";

                bearerOption.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidAudience = "vn8tujv2rd0f38i1q0s918afb",

                    ValidateLifetime = true,

                    ValidateIssuer = true,
                    ValidIssuer = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_pggIi40GB"
                };

                bearerOption.MetadataAddress = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_pggIi40GB/.well-known/openid-configuration";
                //bearerOption.ConfigurationManager = 
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", builder =>
                {
                    //builder.RequireRole("Admin");
                    builder.RequireClaim("cognito:groups", "admin");
                });

                options.AddPolicy("read", builder =>
                {
                    //builder.RequireRole("Admin");
                    builder.RequireClaim("cognito:groups", "read");
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoAPI", Version = "v1" });
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
