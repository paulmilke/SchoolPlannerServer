namespace SchoolPlanner.Data.Models;

public class Term
{
    public int TermId { get; set; }
    public required string TermName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
