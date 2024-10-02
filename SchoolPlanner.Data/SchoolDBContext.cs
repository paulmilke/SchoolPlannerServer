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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Term>().Property<DateTime>("UpdatedOn"); 
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetTimeStamps(); 
            return await base.SaveChangesAsync(cancellationToken);
        }


        private void SetTimeStamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Term && (e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                entry.Property("UpdatedOn").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
