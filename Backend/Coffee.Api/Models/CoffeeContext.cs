using Microsoft.EntityFrameworkCore;

namespace Coffee.Api.Models
{
    public class CoffeeContext : DbContext
    {
        public DbSet<CoffeeModel> Coffees { get; set; }

        public CoffeeContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoffeeModel>().ToTable("coffee", "production");
        }
    }
}
