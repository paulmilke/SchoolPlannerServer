using SchoolPlanner.Data.Models;

namespace SchoolPlanner.Data.Interfaces
{
    public interface IAssessmentRepository
    {
        Task<List<Assessment>> GetAssessmentsAsync(int classId);
        Task<Assessment?> GetSingleAssessmentAsync(int assessmentId);
        Task<int> UpdateAssessmentAsync(Assessment updatedAssessment);
        Task<int> AddAssessmentAsync(Assessment newAssessment);
        Task<int> DeleteAssessmentAsync(int assessmentId); 
    }
}
