using Microsoft.EntityFrameworkCore;
using ASPNETProdactAndCategory.Models;

namespace ASPNETProdactAndCategory.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Prodact> Prodacts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}