using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WeatherAPI.Model;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
  private readonly ILogger<WeatherController> _logger;
  private readonly IWeatherService _weatherService;
  
  public WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService)
  {
    _logger = logger;
    _weatherService = weatherService;
  }

  [HttpGet]
  [Route("countries")]
  public IActionResult GetCountries()
  {
    var countries = _weatherService.GetCountries().Select(x => new CountryModel
    {
      Text = x,
      Value = x
    });
    return new ObjectResult(countries);
  }

  [HttpGet]
  public IActionResult GetCountryWeather([FromQuery] string? countryCode)
  {
    List<JObject> weatherData = _weatherService.GetWeatherFromJSONFiles();
    
    var res = new GetCountryWeatherResponseModel();
    res.Countries = new List<CountryWeatherModel>();
    res.IntervalOrder = new List<string> { "12 AM", "3 AM", "6 AM", "9 AM", "12 PM", "3 PM", "6 PM", "9 PM" };
    res.Dates = null;
    
    foreach (var c in weatherData)
    {
      var country = c.SelectToken("$.location.country").ToObject<string>();
      var dates = c.SelectToken("$.forecast.forecastday").Select(x => x.SelectToken("date").ToObject<string>()).ToList();

      if (res.Dates == null) res.Dates = dates;
      
      var countryWeather = new CountryWeatherModel
      {
        Country = country, 
        CountryCode = country,
        Dates = new List<CountryDateWeatherModel>()
      };
      res.Countries.Add(countryWeather);

      foreach (var d in dates)
      {
        var countryDate = new CountryDateWeatherModel { Date = d, Weather = new List<CurrentWeatherModel>() };
        countryWeather.Dates.Add(countryDate);
          
        var hourArray = c.SelectToken($"$.forecast.forecastday.[?(@.date == '{d}')].hour").ToObject<JArray>();
        string currentTime = "00:00";
          
        foreach (var h in hourArray)
        {
          string time = h.SelectToken("$.time").ToObject<string>().Split(" ")[1];
          if (!string.Equals(time, currentTime)) continue;
            
          string tempC = h.SelectToken("$.temp_c").ToObject<string>();
          string tempF = h.SelectToken("$.temp_f").ToObject<string>();
          string icon = "https:" + h.SelectToken("$.condition.icon").ToObject<string>();

          countryDate.Weather.Add(new CurrentWeatherModel
          {
            TempC = tempC,
            TempF = tempF,
            Icon = icon,
            Interval = time
          });
            
          var newTime = TimeSpan.Parse(time).Add(TimeSpan.FromHours(3));
          currentTime = newTime.ToString(@"hh\:mm");
        }
      }
    }
    
    if (!string.IsNullOrEmpty(countryCode))
    {
      res.Countries = res.Countries.Where(x => string.Equals(x.CountryCode, countryCode)).ToList();
    }

    return new ObjectResult(res);
  }

  /*
  [HttpGet]
  [Route("forecast")]
  public IActionResult GetWeatherForecast([FromQuery] string? countryCode, [FromQuery] DateTime startDate)
  {
    var res = new GetWeatherForecastResponseModel();
    res.Dates = new List<string>
    {
      new DateTime(2024, 3, 2).ToString("s"),
      new DateTime(2024, 3, 3).ToString("s"),
      new DateTime(2024, 3, 4).ToString("s"),
      new DateTime(2024, 3, 5).ToString("s"),
      new DateTime(2024, 3, 6).ToString("s"),
      new DateTime(2024, 3, 7).ToString("s"),
      new DateTime(2024, 3, 8).ToString("s"),
    };
    res.Countries = new List<CountryForecastWeatherModel>();
    var countries = GetDummyCountries();
    
    if (string.IsNullOrEmpty(countryCode))
    {
      foreach (var c in countries)
      {
        res.Countries.Add(new CountryForecastWeatherModel
        {
          Country = c.Text,
          CountryCode = c.Value,
          Forecast = GetDummyForecast()
        });
      }
    }
    else
    {
      var country = countries.FirstOrDefault(x => string.Equals(x.Value, countryCode));
      if (country == null) return BadRequest();
      res.Countries.Add(new CountryForecastWeatherModel
      {
        Country = country.Text,
        CountryCode = country.Value,
        Forecast = GetDummyForecast()
      });
    }
    
    return new ObjectResult(res);
  }
  */

  /*
  private List<CountryModel> GetDummyCountries()
  {
    var res = new List<CountryModel>();
    res.Add(new CountryModel { Text = "Singapore", Value = "SG" });
    res.Add(new CountryModel { Text = "Malaysia", Value = "MY" });
    res.Add(new CountryModel { Text = "Philippines", Value = "PH" });
    res.Add(new CountryModel { Text = "Thailand", Value = "TH" });
    res.Add(new CountryModel { Text = "Japan", Value = "JP" });
    return res;
  }

  private List<CurrentWeatherModel> GetDummyWeather()
  {
    var res = new List<CurrentWeatherModel>();
    res.Add(new CurrentWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Interval = "12 AM" });
    res.Add(new CurrentWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Interval = "3 AM" });
    res.Add(new CurrentWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Interval = "6 AM" });
    res.Add(new CurrentWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Interval = "9 AM" });
    res.Add(new CurrentWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Interval = "12 PM" });
    res.Add(new CurrentWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Interval = "3 PM" });
    res.Add(new CurrentWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Interval = "6 PM" });
    res.Add(new CurrentWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Interval = "9 PM" });
    return res;
  }

  private List<ForecastWeatherModel> GetDummyForecast()
  {
    var res = new List<ForecastWeatherModel>();
    res.Add(new ForecastWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Date = new DateTime(2024, 3, 2).ToString("s")});
    res.Add(new ForecastWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Date = new DateTime(2024, 3, 3).ToString("s")});
    res.Add(new ForecastWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Date = new DateTime(2024, 3, 4).ToString("s")});
    res.Add(new ForecastWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Date = new DateTime(2024, 3, 5).ToString("s")});
    res.Add(new ForecastWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Date = new DateTime(2024, 3, 6).ToString("s")});
    res.Add(new ForecastWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Date = new DateTime(2024, 3, 7).ToString("s")});
    res.Add(new ForecastWeatherModel { TempC = "27.1", TempF = "77.7", Icon = "https://cdn.weatherapi.com/weather/64x64/day/353.png", Date = new DateTime(2024, 3, 8).ToString("s")});
    return res;
  }
  */
}