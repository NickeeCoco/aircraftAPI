using AircraftDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AircraftInfrastructure.Data
{
    public class AircraftContext : DbContext
    {
        //private readonly IConfiguration _configuration;

        /*public AircraftContext(IConfiguration configuration) 
        {
            _configuration = configuration;
        }*/

        public AircraftContext(DbContextOptions<AircraftContext> options) : base(options) {}

        public virtual DbSet<Aircraft> Aircrafts { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            if (!optionsBuilder.IsConfigured) 
            { 
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("aircraftsDb"));
            } 
        }*/

    }

   
}
