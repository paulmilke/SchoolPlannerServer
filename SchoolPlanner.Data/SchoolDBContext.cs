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
            modelBuilder.Entity<Term>().Property<DateTime>("UpdatedOn"); //Shadow property
        }

        //Overrides the standard SaveChangesAsync method to include the updateon change. 
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetTimeStamps(); 
            return await base.SaveChangesAsync(cancellationToken);
        }

        //Updates the UpdateOn column for the Term table. 
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
