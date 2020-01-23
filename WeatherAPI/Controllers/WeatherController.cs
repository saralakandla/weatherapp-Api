using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WeatherAPI.Services.Interface;
using WeatherAPI.Entities;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWeatherForecastService _weatherService;

        public WeatherController(IConfiguration configuration, IWeatherForecastService weatherService)
        {
            _configuration = configuration;
            _weatherService = weatherService;
        }

        /// <summary>
        /// Get Weather Forecast by City
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("forecast/{inputValue}/{isCity}")]
        [Produces(typeof(List<WeatherEntity>))]
        public IActionResult GetForecast(string inputValue, bool isCity)
        {
            var response = _weatherService.GetForecast(inputValue, isCity);
            return Ok(response);
        }

        /// <summary>
        /// Get Weather Forecast by City
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("current/{inputValue}/{isCity}")]
        [Produces(typeof(WeatherEntity))]
        public IActionResult GetCurrentWeather(string inputValue, bool isCity)
        {
            var response = _weatherService.GetCurrentWeather(inputValue, isCity);
            return Ok(response);
        }


    }
}