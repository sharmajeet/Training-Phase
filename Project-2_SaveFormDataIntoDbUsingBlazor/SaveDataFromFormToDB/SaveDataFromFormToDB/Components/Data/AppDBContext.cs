using Microsoft.EntityFrameworkCore;
using SaveDataFromFormToDB.Models;

namespace SaveDataFromFormToDB.Components.Data
{
    public class AppDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AppDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(Configuration.GetConnectionString("DbConncectionString"));
        }

        public DbSet<Country> Countries { get; set; }   
    }
}
