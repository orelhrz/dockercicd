using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastApp.Controllers;
using WeatherForecastApp.Models;
using Xunit;

namespace WeatherForecastApp.Controllers
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public async Task Get_ReturnsWeatherForecasts()
        {
            // Arrange
            var mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(c => c.GetConnectionString("DefaultConnection"))
                      .Returns("FakeConnectionString");

            var controller = new TestableWeatherForecastController(mockConfig.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var forecasts = Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
            Assert.NotNull(forecasts);
            Assert.Collection(forecasts,
                item =>
                {
                    Assert.Equal(new DateTime(2024, 1, 1), item.Date);
                    Assert.Equal(25, item.TemperatureC);
                    Assert.Equal("Sunny", item.Summary);
                },
                item =>
                {
                    Assert.Equal(new DateTime(2024, 1, 2), item.Date);
                    Assert.Equal(18, item.TemperatureC);
                    Assert.Equal("Cloudy", item.Summary);
                }
            );
        }

        private class TestableWeatherForecastController : WeatherForecastController
        {
            public TestableWeatherForecastController(IConfiguration config) : base(config) { }

            public override async Task<IEnumerable<WeatherForecast>> Get()
            {
                await Task.Yield();
                return new List<WeatherForecast>
                {
                    new WeatherForecast { Date = new DateTime(2024, 1, 1), TemperatureC = 25, Summary = "Sunny" },
                    new WeatherForecast { Date = new DateTime(2024, 1, 2), TemperatureC = 18, Summary = "Cloudy" }
                };
            }
        }
    }
}