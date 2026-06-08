using Avia.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Avia.DataAccessLayer.Contexts
{
    public class AviaContext : DbContext
    {
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<AirportEntity> Airports { get; set; }

        public AviaContext() {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(config["ConnectionString"]);
        }
    }
}
