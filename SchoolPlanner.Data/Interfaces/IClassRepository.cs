

using SchoolPlanner.Data.Models;

namespace SchoolPlanner.Data.Interfaces
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetClassesAsync(int termId); 
        Task<Class> AddClassAsync(Class newClass);
    }
}
