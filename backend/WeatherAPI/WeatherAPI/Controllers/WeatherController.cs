using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherAPI.Model;

namespace WeatherAPI.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
  private readonly ILogger<WeatherController> _logger;
  
  public WeatherController(ILogger<WeatherController> logger)
  {
    
  }

  [HttpGet]
  [Route("countries")]
  public IActionResult GetCountries()
  {
    return new ObjectResult(GetDummyCountries());
  }

  [HttpGet]
  public IActionResult GetCountryWeather([FromQuery] string? countryCode)
  {
    var res = new GetCountryWeatherResponseModel();
    res.Countries = new List<CountryWeatherModel>();
    res.IntervalOrder = new List<string> { "12 AM", "3 AM", "6 AM", "9 AM", "12 PM", "3 PM", "6 PM", "9 PM" };
    var countries = GetDummyCountries();

    if (string.IsNullOrEmpty(countryCode))
    {
      foreach (var c in countries)
      {
        res.Countries.Add(new CountryWeatherModel
        {
          Country = c.Text,
          CountryCode = c.Value,
          Weather = GetDummyWeather()
        });
      }
    }
    else
    {
      var country = countries.FirstOrDefault(x => string.Equals(x.Value, countryCode));
      if (country == null) return BadRequest();
      res.Countries.Add(new CountryWeatherModel
      {
        Country = country.Text,
        CountryCode = country.Value,
        Weather = GetDummyWeather()
      });
    }

    return new ObjectResult(res);
  }

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
}