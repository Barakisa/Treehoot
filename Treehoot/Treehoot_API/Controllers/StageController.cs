using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Treehoot_API.Models;
using System;
using System.IO;
using System.Text.Json;

namespace Treehoot_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StageController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private Quiz[] GetStagesFromDB()
        {
            string filePath = "path_to_your_json_file.json";

            try
            {
                string jsonContent = File.ReadAllText(filePath);

                // Deserialize the JSON content into your object
                YourObjectType obj = JsonSerializer.Deserialize<YourObjectType>(jsonContent);

                // Now 'obj' contains the deserialized data from your JSON file
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private readonly ILogger<StageController> _logger;

        public StageController(ILogger<StageController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStage")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}