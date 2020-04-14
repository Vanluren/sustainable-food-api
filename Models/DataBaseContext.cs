
using Microsoft.EntityFrameworkCore;

namespace sustainable_food_api.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
