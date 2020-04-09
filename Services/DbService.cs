using Microsoft.EntityFrameworkCore;
using sustainable_food_api.Models;

namespace sustainable_food_api.Services
{
    public class DbService : DbContext
    {
        public DbService(DbContextOptions<DbService> opt)
                    : base(opt)
        {
        }
        public DbSet<User> Users { get; set; }
    }

}
