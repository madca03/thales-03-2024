using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAPI.Model;

public class CountryWeatherModel
{
    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("countryCode")]
    public string CountryCode { get; set; }

    [JsonProperty("dates")]
    public List<CountryDateWeatherModel> Dates { get; set; }
}