using MegaOneMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaOneMvc.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Deal> Deals { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
