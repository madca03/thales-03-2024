using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StudentEnrollment.API.Models.Shared.ResponseModel;

public class BaseDataAPIResponseModel : BaseAPIResponseModel
{
    [JsonProperty("data")]
    [JsonPropertyName("data")]
    public object Data { get; set; }
}