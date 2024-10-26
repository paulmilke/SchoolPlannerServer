using Microsoft.EntityFrameworkCore;
using SchoolPlanner.Data.Interfaces;
using SchoolPlanner.Data.Models; 

namespace SchoolPlanner.Data.Repositories
{
    public class AssessmentRepository : IAssessmentRepository
    {
        SchoolDBContext _dbContext;
        public AssessmentRepository(SchoolDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Assessment>> GetAssessmentsAsync(int classId)
        {
            var assessments = await _dbContext.Assessments.Where(c => c.ClassId == classId).ToListAsync();
            return assessments; 
        }

        public async Task<Assessment?> GetSingleAssessmentAsync(int assessmentId)
        {
            var assessment = await _dbContext.Assessments.Where(x => x.AssessmentId == assessmentId).SingleOrDefaultAsync();
            return assessment; 
        }

        public async Task<int> UpdateAssessmentAsync(Assessment updatedAssessment)
        {
            var updated = _dbContext.Assessments.Update(updatedAssessment);
            return await _dbContext.SaveChangesAsync(); 
        }

        public async Task<int> AddAssessmentAsync(Assessment newAssessment)
        {
            var added = _dbContext.Assessments.Add(newAssessment);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAssessmentAsync(int assessmentId)
        {
            return await _dbContext.Assessments.Where(x => x.AssessmentId == assessmentId).ExecuteDeleteAsync();
        }
    }
}
