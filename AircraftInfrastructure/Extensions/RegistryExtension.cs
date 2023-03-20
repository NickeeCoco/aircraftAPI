using AircraftCore.Interfaces;
using AircraftInfrastructure.Data;
using AircraftInfrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AircraftInfrastructure.Extensions
{
    public static class RegistryExtension
    {
        public static void AddDatabaseRegistry(this IServiceCollection services)
        {
            services.AddDbContext<AircraftContext>(opt =>
                opt.UseInMemoryDatabase("AircraftsDb"));
        }

        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddScoped<IAircraftService, AircraftService>();
        }
    }
}
