using System.Data.Entity;

namespace Ajf.IdentityServer3.Models.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("IdentityServerConnection")
        {
        }

        public static void UpdateDatabase()
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        //public DbSet<Event> Events { get; set; }
        //public DbSet<Car> Cars { get; set; }
        //public DbSet<Passenger> Passengers { get; set; }
        public DbSet<User> Users { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}