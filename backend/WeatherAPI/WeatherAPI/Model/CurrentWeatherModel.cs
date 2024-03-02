using Newtonsoft.Json;

namespace WeatherAPI.Model;

public class CurrentWeatherModel
{
    [JsonProperty("tempC")]
    public string TempC { get; set; }
    
    [JsonProperty("tempF")]
    public string TempF { get; set; }
    
    [JsonProperty("icon")]
    public string Icon { get; set; }

    [JsonProperty("interval")]
    public string Interval { get; set; }
}