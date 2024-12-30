using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantApp_Model.Entities;

namespace RestaurantApp_Database.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TableModal> Table { get; set; }
        public DbSet<BookingsModel> Bookings { get; set; }

    }
}
