using Newtonsoft.Json;

namespace WeatherAPI.Model;

public class CountryModel
{ 
  [JsonProperty("text")]
  public string Text { get; set; }
  
  [JsonProperty("value")]
  public string Value { get; set; }
}