using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace WeatherAPI.Services;

public interface IWeatherService
{
    List<JObject> GetWeatherFromJSONFiles();
    List<string> GetCountries();
}