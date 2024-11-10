using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StudentEnrollment.API.Models.Enrollment.RequestModel;

public class UpdateEnrollmentStatusRequestModel
{
    [Required]
    [JsonProperty("status")]
    [JsonPropertyName("status")]
    public string Status { get; set; }
}