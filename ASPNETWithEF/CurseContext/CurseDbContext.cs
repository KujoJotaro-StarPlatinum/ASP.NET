using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPNETWithEF.CurseContext
{
    public class CurseDbContext : DbContext
    {
        public CurseDbContext()
        {
        }

        public CurseDbContext(DbContextOptions<CurseDbContext> options) : base(options) { }

        public DbSet<Models.Curse> Curses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOPOFBATON; database=ASPNETStudent; Integrated Security=true;TrustServerCertificate=True");
        }
    }
}
