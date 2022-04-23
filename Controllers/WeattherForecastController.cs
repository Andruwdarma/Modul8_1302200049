using Microsoft.AspNetCore.Mvc;

namespace modul8_1302200049.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeattherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeattherForecastController> _logger;

        public WeattherForecastController(ILogger<WeattherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeattherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeattherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}