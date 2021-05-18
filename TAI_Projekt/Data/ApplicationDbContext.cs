using Microsoft.EntityFrameworkCore;
using TAI_Projekt.Models.DbModels;

namespace TAI_Projekt.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasIndex(entity => new { entity.Name }).IsUnique();
        
            base.OnModelCreating(modelBuilder);
        }

    }
}