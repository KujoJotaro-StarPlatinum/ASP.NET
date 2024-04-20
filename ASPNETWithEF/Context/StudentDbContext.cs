using ASPNETWithEF.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETWithEF.Context
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext()
        {
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("server=LAPTOPOFBATON; database=ASPNETStudent; Integrated Security=true;TrustServerCertificate=True");
        }
    }
} 