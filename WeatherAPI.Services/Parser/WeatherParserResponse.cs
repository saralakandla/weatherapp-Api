using System;
using System.Collections.Generic;
using WeatherAPI.Entities;
using WeatherAPI.Client;
using System.Linq;
using WeatherAPI.Client.Current;

namespace WeatherAPI.Services.Parser
{
    public class WeatherParserResponse
    {

        public const string Hiphen = " - ";
        /// <summary>
        /// Convert forecast weather respone to Weather Entity 
        ///  and update city value with Zipcode if the response is from zipcode
        /// </summary>
        /// <param name="forecast"></param>
        /// <param name="inputValue"></param>
        /// <param name="isCity"></param>
        /// <returns></returns>
        public List<WeatherEntity> GetWeatherData(WeatherForecast forecast, string inputValue, bool isCity)
        {

            var weatherData = new List<WeatherEntity>();
            var weatherList = forecast.List.GroupBy(x => x.DtTxt.Day);
            foreach (var weather in weatherList)
            {
                var city = isCity ? forecast.City.Name : string.Concat(forecast.City.Name, Hiphen, inputValue);
                var date = weather.FirstOrDefault().DtTxt.Date;

                // Calculate Average Temperature from the list of temperatures for the day

                var avgTemp = (int)weather.Average(w => w.Main.Temp);
                var avghumidity = (int)weather.Average(w => w.Main.Humidity);
                var avgwind = (int)weather.Average(w => w.Wind.Speed);
                var icon = (int)weather.FirstOrDefault().Weather.FirstOrDefault().Id;
                var description = weather.FirstOrDefault().Weather.FirstOrDefault().Description;
                weatherData.Add(new WeatherEntity(city, date, avgTemp, avghumidity, avgwind, description, icon));
            }
            return weatherData;

        }

        /// <summary>
        ///  Convert current weather respone to Wheather Entity 
        ///  and update city value  with Zipcode if the response is from zipcode
        /// </summary>
        /// <param name="weather"></param>
        /// <param name="inputValue"></param>
        /// <param name="isCity"></param>
        /// <returns></returns>
        public WeatherEntity GetWeatherData(CurrentWeather weather, string inputValue, bool isCity)
        {
            try
            {
                return new WeatherEntity(
                             isCity ? weather.Name : string.Concat(weather.Name, Hiphen, inputValue),
                           Utililty.UnixTimeStampToDateTime(weather.Dt),
                             (int)weather.Main.Temp,
                             (int)weather.Main.Humidity,
                             (int)weather.Wind.Speed,
                             weather.Weather.FirstOrDefault().Description,
                             (int)weather.Weather.FirstOrDefault().Id
                             );
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
