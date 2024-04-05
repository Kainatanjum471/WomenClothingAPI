using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WomenClothingAPI.Models;

namespace WomenClothingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
