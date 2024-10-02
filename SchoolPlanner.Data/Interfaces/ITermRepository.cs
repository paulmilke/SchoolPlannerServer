

using SchoolPlanner.Data.Models;

namespace SchoolPlanner.Data.Interfaces
{
    public interface ITermRepository
    {
        Task<IEnumerable<Term>> GetAllTermsAsync();
        Task<Term> AddNewTermAsync(Term newTerm);
        Task<Term> UpdateExistingTermAsync(Term updatedTerm); 
    }
}
