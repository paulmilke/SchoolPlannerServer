using Microsoft.EntityFrameworkCore;
using SchoolPlanner.Data.Models;

namespace SchoolPlanner.Data
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options) 
        { 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Term> Terms { get; set; }

    }
}
