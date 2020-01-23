using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using WeatherAPI.Client.Current;

namespace WeatherAPI.Client
{
    public class WeatherApiClient : BaseClient
    {

      
        public WeatherApiClient(IConfiguration configuration, ICacheService cache) : base(configuration, cache)
        {


        }
        /// <summary>
        /// Get forecast data from open weather map by city 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public WeatherForecast GetForecastByCity(string city)
        {

            try
            {
                var request = new RestRequest(string.Format(Constants.CityURL, city, apiKey));
                request.Method = Method.GET;
                request.RequestFormat = DataFormat.Json;
                var response = GetFromCache<WeatherForecast>(request, string.Concat(Constants.CachcekeyUniqueCity, city));
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get forecast data from open weather map by zipcode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public WeatherForecast GetForecastByZipCode(string zipCode)
        {
            try
            {
                var request = new RestRequest(string.Format(Constants.ZipURL, zipCode, apiKey));
                request.Method = Method.GET;
                request.RequestFormat = DataFormat.Json;
                var response = GetFromCache<WeatherForecast>(request, string.Concat(Constants.CachcekeyUniqueZip, zipCode));
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Get current weather data from open weather map by City
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public CurrentWeather GetCurrentWeatherByCity(string city)
        {

            try
            {
                var request = new RestRequest(string.Format(Constants.WeatherCityURL, city, apiKey));
                request.Method = Method.GET;
                request.RequestFormat = DataFormat.Json;
                var response = GetFromCache<CurrentWeather>(request, string.Concat(Constants.CachcekeyUniqueCity, city, Constants.CachekeyUniqueCurrent));
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get current weather data from open weather map by zipCode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public CurrentWeather GetCurrentWeatherByZipCode(string zipCode)
        {

            try
            {
                var request = new RestRequest(string.Format(Constants.WeatherZipURL, zipCode, apiKey));
                request.Method = Method.GET;
                request.RequestFormat = DataFormat.Json;
                var response = GetFromCache<CurrentWeather>(request, string.Concat(Constants.CachcekeyUniqueZip , zipCode , Constants.CachekeyUniqueCurrent));
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
