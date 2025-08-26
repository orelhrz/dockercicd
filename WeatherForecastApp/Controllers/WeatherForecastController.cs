using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private IConfiguration config;

        public WeatherForecastController(IConfiguration config)
        {
            this.config = config;
        }


        [HttpGet]
        public virtual async Task<IEnumerable<WeatherForecast>> Get()
        {
            await Task.Yield();
            var forecasts = new WeatherForecast[5];
            for (var i = 0; i < 5; i++)
            {
                forecasts[i] = new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
            }
            return forecasts;
        }
    }
}