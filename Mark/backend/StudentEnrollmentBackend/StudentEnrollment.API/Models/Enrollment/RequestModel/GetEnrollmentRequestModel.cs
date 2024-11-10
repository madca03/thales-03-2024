namespace StudentEnrollment.API.Models.Enrollment.RequestModel;

public class GetEnrollmentRequestModel
{
    public string CourseName { get; set; }
    public string StudentName { get; set; }
    public DateTime? EnrollmentDate { get; set; }
    public int? Limit { get; set; }
    public int? Offset { get; set; }
}