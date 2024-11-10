namespace StudentEnrollment.API.Models.Course.RequestModel;

public class GetCoursesRequestModel
{
    public string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Limit { get; set; }
    public int? Offset { get; set; }
}