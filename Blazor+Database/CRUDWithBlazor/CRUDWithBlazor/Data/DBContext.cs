using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDWithBlazor.Models;

namespace CRUDWithBlazor.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<CRUDWithBlazor.Models.Product> Product { get; set; } = default!;
    }
}
