using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudOprUsingBlazor.Models;

namespace CrudOprUsingBlazor.Data
{
    public class MyAppDB : DbContext
    {
        public MyAppDB (DbContextOptions<MyAppDB> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;
    }
}
