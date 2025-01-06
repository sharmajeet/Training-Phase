using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant_Models.Entities;

namespace Restaurant_Database.Data
{
    public  class AppDbContext :DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }   
        public DbSet<TableModel> Tables { get; set; }

        public DbSet<BookingModel> Bookings { get; set; }
    }
}
