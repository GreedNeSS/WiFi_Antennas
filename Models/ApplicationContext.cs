using Microsoft.EntityFrameworkCore;

namespace WiFi_Antennas_Win.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Antenna> Antennas { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)
        {
            Database.EnsureCreated();
        }
    }
}
