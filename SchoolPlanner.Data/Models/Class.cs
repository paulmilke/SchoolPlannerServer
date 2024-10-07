

namespace SchoolPlanner.Data.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public int TermId { get; set; }
        public required string ClassName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public required string Status { get; set; }
        public required string InstructorName { get; set; }
        public required string InstructorPhone { get; set; }
        public required string InstructorEmail { get; set; }
        public string? Notes {get; set; }
    }
}
