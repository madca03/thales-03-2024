using System.Collections.Generic;

namespace WeatherAPI.Model;

public class CountryForecastWeatherModel
{
    public string Country { get; set; }
    public string CountryCode { get; set; }
    public List<ForecastWeatherModel> Forecast { get; set; }
}