using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAPI.Model;

public class GetWeatherForecastResponseModel
{
    [JsonProperty("dates")]
    public List<string> Dates { get; set; }

    [JsonProperty("countries")]
    public List<CountryForecastWeatherModel> Countries { get; set; }
}