using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherAPI.Services;

public class WeatherService : IWeatherService
{
    private readonly ILogger<WeatherService> _logger;
    private readonly IConfiguration _configuration;
    
    public WeatherService(ILogger<WeatherService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public List<string> GetCountries()
    {
        var folderPath = _configuration.GetValue<string>("FolderPath");
        if (string.IsNullOrEmpty(folderPath)) throw new Exception("Folder Path is missing");
        
        var files = Directory.GetFiles(folderPath);

        return files.Select(f => Path.GetFileNameWithoutExtension(f)).ToList();
    }
    
    public List<JObject> GetWeatherFromJSONFiles()
    {
        var res = new List<JObject>();
        var folderPath = _configuration.GetValue<string>("FolderPath");
        if (string.IsNullOrEmpty(folderPath)) throw new Exception("Folder Path is missing");

        var files = Directory.GetFiles(folderPath);
        foreach (var f in files)
        {
            var fileContents = File.ReadAllText(f);
            var json = JObject.Parse(fileContents);
            res.Add(json);
        }

        return res;
    }
}