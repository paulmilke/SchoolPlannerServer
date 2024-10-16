

namespace SchoolPlanner.Data.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public int TermId { get; set; }
        public required string ClassName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Status { get; set; }
        public string? InstructorName { get; set; }
        public string? InstructorPhone { get; set; }
        public string? InstructorEmail { get; set; }
        public string? Notes {get; set; }
    }
}
