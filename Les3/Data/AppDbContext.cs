using Microsoft.EntityFrameworkCore;

namespace Les3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Models.User> Users => Set<Models.User>();
        public DbSet<Models.Product> Products => Set<Models.Product>();
    }
}