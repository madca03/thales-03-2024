using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment.API.Models.Course.RequestModel;

public class CreateCourseRequestModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }
    
    [Required]
    public DateTime? StartDate { get; set; }
    
    [Required]
    public DateTime? EndDate { get; set; }
    
    [Required]
    public double? Fees { get; set; }
    
    [Required]
    public string LocationAddress { get; set; }
    
    [Required]
    public string ContactPerson { get; set; }   
}