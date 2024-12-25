using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Data
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Table entity
            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasKey(t => t.Id); // Set primary key
                entity.Property(t => t.Location)
                      .IsRequired() // Make Location required
                      .HasMaxLength(100); // Set max length for Location

                entity.Property(t => t.NumberOfSeats)
                      .IsRequired(); // Make NumberOfSeats required

                // Seed initial data for Table
                entity.HasData(
                    new Table { Id = 1, Location = "Window", NumberOfSeats = 4 },
                    new Table { Id = 2, Location = "Center", NumberOfSeats = 2 },
                    new Table { Id = 3, Location = "Patio", NumberOfSeats = 6 }
                );
            });

            // Configure Reservation entity
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(r => r.Id); // Set primary key
                entity.Property(r => r.ReservationTime)
                      .IsRequired(); // Make ReservationDateTime required

                // Configure foreign key relationship
                //entity.HasOne(r => r.Table)
                //      .WithMany(t => t.Reservations)
                //      .HasForeignKey(r => r.TableId)
                //      .OnDelete(DeleteBehavior.Cascade); // Set delete behavior
            });
        }
    }
}


//1

//using Microsoft.EntityFrameworkCore;
//using RestaurantManagementSystem.Models;

//namespace RestaurantManagementSystem.Data
//{
//    public class RestaurantDbContext : DbContext
//    {
//        public DbSet<Table> Tables { get; set; }
//        public DbSet<Reservation> Reservations { get; set; }

//        // Constructor to accept DbContextOptions
//        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
//        {
//        }

//        // Optional: Override OnModelCreating if you need to configure the model further
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Configure your model here if needed
//        }
//    }
//}


//default

//using Microsoft.AspNetCore.Hosting.Server;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

//namespace RestaurantManagementSystem.Data
//{
//    public class RestaurantDbContext : DbContext
//    {
//        public DbSet<Table> Tables { get; set; }
//        public DbSet<Models.Reservation> Reservations { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = RestaurantDemo; Trusted_Connection = True; MultipleActiveResultSets = True");
//        }
//    }
//}
