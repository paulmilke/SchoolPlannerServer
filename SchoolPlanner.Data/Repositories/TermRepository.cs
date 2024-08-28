using Microsoft.EntityFrameworkCore;
using SchoolPlanner.Data.Interfaces;
using SchoolPlanner.Data.Models; 

namespace SchoolPlanner.Data.Repositories
{
    public class TermRepository : ITermRepository
    {
        private readonly SchoolDBContext _dbContext;

        public TermRepository(SchoolDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Term>> GetAllTermsAsync()
        {
            return await _dbContext.Terms.ToListAsync(); 
        }

        public async Task<Term> AddNewTermAsync(Term newTerm)
        {
            await _dbContext.Terms.AddAsync(newTerm);
            await _dbContext.SaveChangesAsync();

            return newTerm; 
        }
    }
}
