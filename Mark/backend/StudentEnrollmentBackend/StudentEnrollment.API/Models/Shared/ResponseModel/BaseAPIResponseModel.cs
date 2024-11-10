using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StudentEnrollment.API.Constants;

namespace StudentEnrollment.API.Models.Shared.ResponseModel;

public class BaseAPIResponseModel
{
    [JsonProperty("statusCode")]
    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }

    [JsonProperty("message")]
    [JsonPropertyName("message")]
    public string Message { get; set; }
    
    public BaseAPIResponseModel()
    {
        StatusCode = APIStatusCode.SUCCESS;
    }
}