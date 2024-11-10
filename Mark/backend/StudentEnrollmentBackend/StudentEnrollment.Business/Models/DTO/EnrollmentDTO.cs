namespace StudentEnrollment.Business.Models.DTO;

public class EnrollmentDTO
{
    public int Id { get; set; }
    public string StudentName { get; set; }
    public string CourseName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Status { get; set; } = null!;
    public string? Comments { get; set; }
}