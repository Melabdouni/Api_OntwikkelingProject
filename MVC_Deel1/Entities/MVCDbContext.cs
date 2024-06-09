using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MVC_Deel1.Entities
{
    public class MVCDbContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Utility> Utilities { get; set; } = null!;

        public MVCDbContext(DbContextOptions options) : base(options) 
        {

        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserUtility>()
                .HasKey(uu => new { uu.UserId, uu.UtilityId });
            modelBuilder.Entity<Building>()
                .HasMany(b => b.Users)
                .WithOne(u => u.Building)
                ;

            base.OnModelCreating(modelBuilder);  // Other configurations for your entities and relationships
        }
    }
}
