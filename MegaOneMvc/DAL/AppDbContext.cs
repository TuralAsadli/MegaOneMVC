using MegaOneMvc.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MegaOneMvc.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Deal> Deals { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
