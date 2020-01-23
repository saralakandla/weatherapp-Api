using System.Collections.Generic;
using WeatherAPI.Entities;

namespace WeatherAPI.Services.Interface
{
    /// <summary>
    /// Interface for Weather Forecast Service
    /// </summary>
    public interface IWeatherForecastService
    {
        List<WeatherEntity> GetForecast(string inputValue, bool isCity);
        WeatherEntity GetCurrentWeather(string inputValue, bool isCity);
    }
}
