using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using WeatherAPI.Client;
using WeatherAPI.Entities;
using WeatherAPI.Services.Parser;
using WeatherAPI.Services.Interface;

namespace WeatherAPI.Services.Implementation
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IConfiguration _configuration;
        private readonly ICacheService _cache;
        private readonly WeatherApiClient apiClient;
        public WeatherForecastService(IConfiguration configuration, ICacheService cache)
        {
            _configuration = configuration;
            _cache = cache;
            apiClient = new Client.WeatherApiClient(configuration, cache);
        }

        /// <summary>
        /// Get forecast by city or zipcode based on isCity true or false
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="isCity"></param>
        /// <returns></returns>
        public List<WeatherEntity> GetForecast(string inputValue, bool isCity)
        {
            try
            {
                var parser = new WeatherParserResponse();
                var response = new WeatherForecast();
                response = isCity ? apiClient.GetForecastByCity(inputValue) : apiClient.GetForecastByZipCode(inputValue);
                var weatherList = parser.GetWeatherData(response, inputValue, isCity);
                return weatherList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get current weather by city or zipcode based on isCity true or false
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="isCity"></param>
        /// <returns></returns>
        public WeatherEntity GetCurrentWeather(string inputValue, bool isCity)
        {
            try
            {
                var parser = new WeatherParserResponse();
                var response = new Client.Current.CurrentWeather();
                response = isCity ? apiClient.GetCurrentWeatherByCity(inputValue) : apiClient.GetCurrentWeatherByZipCode(inputValue);
                var weather = parser.GetWeatherData(response, inputValue, isCity);
                return weather;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
