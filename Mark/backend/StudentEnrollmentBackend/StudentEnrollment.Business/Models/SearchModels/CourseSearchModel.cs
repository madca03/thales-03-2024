namespace StudentEnrollment.Business.Models.SearchModels;

public class CourseSearchModel : IPaginationSearchModel
{
    public string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Limit { get; set; }
    public int? Offset { get; set; }
}