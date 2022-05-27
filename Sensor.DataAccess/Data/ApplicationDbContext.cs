using Microsoft.EntityFrameworkCore;
using SensorWeb.Sensor.Models;

namespace SensorWeb.Sensor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<SensorModel> Sensors { get; set; }
    }
}
