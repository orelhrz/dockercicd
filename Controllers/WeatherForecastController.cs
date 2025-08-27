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
        [HttpGet("version")]
        public ActionResult<string> GetVersion()
        {
            var version = config["ApiVersion"] ?? "1.0.1";
            return Ok(version);
        }

        [HttpGet]
        public virtual IEnumerable<string> Get()
        {
            return Summaries;
        }


    }
}