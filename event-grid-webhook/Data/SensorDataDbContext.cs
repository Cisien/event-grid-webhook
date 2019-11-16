using Microsoft.EntityFrameworkCore;

namespace EventGridWebhook.Data
{
    public class SensorDataDbContext : DbContext
    {
        public SensorDataDbContext(DbContextOptions<SensorDataDbContext> options) : base(options) { }

        public DbSet<SensorEntry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SensorEntry>().HasIndex(a => a.SampleTime);
            builder.Entity<SensorEntry>().HasIndex(a => a.DeviceId);
        }
    }
}
