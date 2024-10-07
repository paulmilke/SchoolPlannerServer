using Microsoft.EntityFrameworkCore;
using SchoolPlanner.Data.Interfaces;
using SchoolPlanner.Data.Models; 

namespace SchoolPlanner.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        SchoolDBContext _dbContext;

        public ClassRepository(SchoolDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Class>> GetClassesAsync(int termId)
        {
            var classes = await _dbContext.Classes.Where(c => c.TermId == termId).ToListAsync();
            return classes; 
        }

        public async Task<Class> AddClassAsync(Class newClass)
        {
            await _dbContext.Classes.AddAsync(newClass);
            await _dbContext.SaveChangesAsync();
            return newClass;

        }
    }
}
