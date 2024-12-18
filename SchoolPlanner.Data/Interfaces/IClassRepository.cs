﻿

using SchoolPlanner.Data.Models;

namespace SchoolPlanner.Data.Interfaces
{
    public interface IClassRepository
    {
        Task<Class?> GetSingleClassAsync(int classId); 
        Task<IEnumerable<Class>> GetClassesAsync(int termId); 
        Task<Class> AddClassAsync(Class newClass);
        Task<int> UpdateClassAsync(Class updatedClass);
        Task<int> DeleteClassAsync(int classId); 
    }
}
