using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment.API.Models.Course.RequestModel;

public class EditCourseRequestModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public double? Fees { get; set; }
    public string LocationAddress { get; set; }
    public string ContactPerson { get; set; }   
}