using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailInventory
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("\"Server=(localdb)\\\\mssqllocaldb;Database=YourDatabaseName;Trusted_Connection=True;\"\r\n");
        }
    }

}
