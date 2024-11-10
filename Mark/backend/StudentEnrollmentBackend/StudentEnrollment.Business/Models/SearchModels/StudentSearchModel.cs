namespace StudentEnrollment.Business.Models.SearchModels;

public class StudentSearchModel : IPaginationSearchModel
{
    public int? Limit { get; set; }
    public int? Offset { get; set; }
}