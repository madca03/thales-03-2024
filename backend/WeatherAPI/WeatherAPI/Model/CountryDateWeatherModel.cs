using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAPI.Model;

public class CountryDateWeatherModel
{
    [JsonProperty("date")]
    public string Date { get; set; }
    
    [JsonProperty("weather")]
    public List<CurrentWeatherModel> Weather { get; set; }
}