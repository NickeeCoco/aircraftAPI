using AircraftCore;
using AircraftInfrastructure.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace AircraftInfrastructure.Extensions
{
    public static class ControllerExtension
    {
        public static IServiceCollection AddAuthenticationService(this IServiceCollection service)
        {
            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://dev-6tc7yj4bvnbv2tkw.us.auth0.com/authorize";
                options.Audience = "https://aircraftapi/";
            });
            
            return service;
        }

        public static IServiceCollection AddControllersService(this IServiceCollection service)
        {
            service.AddControllers(options =>
            {
                var policies = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policies));
                options.Filters.Add<GlobalExceptionFilter>();
            });
            return service;
        }

        public static IServiceCollection AddCorsService(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            return service;
        }

        public static IServiceCollection AddMediatRService(this IServiceCollection service)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatorEntryPoint).Assembly));
            return service;
        }
    }
}
