using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.EntityFrameworkCore.Extensions;

namespace MobileProjectServer.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Coordinates> Coordinates { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Enter_History> Enter_Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Friends>().HasOne(p => p.FirstUsers).WithMany(p => p.Friends);
            modelBuilder.Entity<Friends>().HasOne(p => p.SecondUsers).WithMany(p => p.Friends1);
        }
    }
}
