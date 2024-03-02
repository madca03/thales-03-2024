using System.Collections.Generic;

namespace WeatherAPI.Model;

public class GetCountryWeatherResponseModel
{
    public List<string> Dates { get; set; }
    public List<string> IntervalOrder { get; set; }
    public List<CountryWeatherModel> Countries { get; set; }
}