using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{            
        //    modelBuilder.Entity<Seat>()
        //        .Property(s => s.IsAvailable)
        //        .HasDefaultValue(true);

        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
