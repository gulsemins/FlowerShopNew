using FlowerShopNew.Areas.Admin.Models;
using FlowerShopNew.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowerShopNew.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> dbContext)
            : base(dbContext) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

    }


}

