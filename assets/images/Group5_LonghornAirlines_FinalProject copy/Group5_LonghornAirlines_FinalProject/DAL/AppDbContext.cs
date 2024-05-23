using Microsoft.EntityFrameworkCore;

//Update this using statement to include your project name
using Group5_LonghornAirlines_FinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;

//Make this namespace match your project name
namespace Group5_LonghornAirlines_FinalProject.DAL
{
    //NOTE: This class definition references the user class for this project.  
    //If your User class is called something other than AppUser, you will need
    //to change it in the line below

    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //this code makes sure the database is re-created on the $5/month Azure tier
            builder.HasPerformanceLevel("Basic");
            builder.HasServiceTier("Basic");

            //// Define foreign key constraints
            //builder.Entity<Tickets>()
            //    .HasOne(t => t.Reservations)
            //    .WithMany(r => r.Tickets)
            //    .HasForeignKey(t => t.Reservations)
            //    .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE NO ACTION

            //builder.Entity<Tickets>()
            //    .HasOne(t => t.Flight)
            //    .WithMany(f => f.Tickets)
            //    .HasForeignKey(t => t.Flight)
            //    .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(builder);
        }

        //Add Dbsets here.  Products is included as an example.  
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<FlightPath> FlightPaths { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }

}