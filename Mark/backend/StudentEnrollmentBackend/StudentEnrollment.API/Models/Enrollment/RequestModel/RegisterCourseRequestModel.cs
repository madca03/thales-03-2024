using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace StudentEnrollment.API.Models.Enrollment.RequestModel;

public class RegisterCourseRequestModel
{
    [Required]
    [JsonProperty("enrollments")]
    public List<RegisterCourseItem> Enrollments { get; set; }
}

public class RegisterCourseItem
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
}