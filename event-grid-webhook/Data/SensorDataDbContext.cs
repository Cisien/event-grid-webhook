using Microsoft.EntityFrameworkCore;
using WeatherLinkClient;

namespace EventGridWebhook.Data
{
    public class SensorDataDbContext : DbContext
    {
        public SensorDataDbContext(DbContextOptions<SensorDataDbContext> options) : base(options) { }

        public DbSet<AirQualitySensorEntry> AirQualityEntries { get; set; }
        public DbSet<WeatherSensorEntry> WeatherEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AirQualitySensorEntry>().HasIndex(a => a.SampleTime);
            builder.Entity<AirQualitySensorEntry>().HasIndex(a => a.DeviceId);
            builder.Entity<WeatherSensorEntry>().HasIndex(a => a.SampleTime);
            builder.Entity<WeatherSensorEntry>().HasIndex(a => a.DeviceId);
        }
    }
}
