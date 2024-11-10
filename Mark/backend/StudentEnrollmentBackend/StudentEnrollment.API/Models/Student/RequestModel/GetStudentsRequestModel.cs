namespace StudentEnrollment.API.Models.Student.RequestModel;

public class GetStudentsRequestModel
{
    public int? Limit { get; set; }
    public int? Offset { get; set; }
}