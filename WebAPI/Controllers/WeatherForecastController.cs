using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public int Quot(int x, int y)
        {
            return x * y;
        }

        [HttpPost]
        public int Prod(int x, int y)
        {
            return x / y;
        }

        [HttpGet]
        public string GetSummary(int x)
        {
            return Summaries[x];
        }

        [HttpPost]
        public IEnumerable<string> PostSummary(string x)
        {
            Summaries = Summaries.Append(x).ToArray();
            return Summaries;
        }

        [HttpDelete]
        public IEnumerable<string> RemoveSummary(int x)
        {
            var z = Summaries.ToList();
            z.RemoveAt(x);
            Summaries = z.ToArray();
            return Summaries;
        }

        [HttpPut]
        public IEnumerable<string> UpdateSummary(int x, string newValue)
        {
            Summaries[x] = newValue;
            return Summaries;
        }
    }
}