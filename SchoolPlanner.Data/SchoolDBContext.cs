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
        public DbSet<Class> Classes { get; set; }
        public DbSet<Assessment> Assessments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Term>().Property<DateTime>("UpdatedOn");
            modelBuilder.Entity<Class>().Property<DateTime>("UpdatedOn");
            modelBuilder.Entity<Assessment>().Property<DateTime>("UpdatedOn"); 
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetTimeStamps(); 
            return await base.SaveChangesAsync(cancellationToken);
        }


        private void SetTimeStamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => (e.Entity is Term || e.Entity is Class || e.Entity is Assessment) && (e.State == EntityState.Modified || e.State == EntityState.Added));

            foreach (var entry in entries)
            {
                entry.Property("UpdatedOn").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
