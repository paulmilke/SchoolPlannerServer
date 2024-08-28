

using SchoolPlanner.Data.Models;

namespace SchoolPlanner.Data.Interfaces
{
    public interface ITermRepository
    {
        Task<IEnumerable<Term>> GetAllTermsAsync();
        Task<bool> AddNewTermAsync(Term newTerm);
    }
}
