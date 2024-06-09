using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MVC_Deel1.Entities
{
    public class MVCDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserUtility>()
                .HasKey(uu => new { uu.UserId, uu.UtilityId });

            // Other configurations for your entities and relationships
        }
        public MVCDbContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<Building> Buildings { get; set; }
    }
}
