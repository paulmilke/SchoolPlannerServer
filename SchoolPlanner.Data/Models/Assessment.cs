
namespace SchoolPlanner.Data.Models
{
    public class Assessment
    {
        public int AssessmentId { get; set; }
        public int ClassId { get; set; }
        public required string AssessmentName { get; set; }
        public required string AssessmentType { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
    }
}
