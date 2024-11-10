namespace StudentEnrollment.Business.Models.SearchModels;

public interface IPaginationSearchModel
{
    int? Limit { get; set; }
    int? Offset { get; set; }
}