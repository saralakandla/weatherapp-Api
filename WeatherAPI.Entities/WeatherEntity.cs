using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAPI.Entities
{
    public class WeatherEntity
    {
        [JsonProperty("city")]
        public string City { get; set; }       
        [JsonProperty("date")]
        public DateTime Date { get; set; }
      
        [JsonProperty("Temperature")]
        public int Temperature { get;  set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("wind")]
        public int WindSpeed { get;  set; }


        [JsonProperty("iconDesc")]
        public string WeatherIconDesc { get; set; }
        [JsonProperty("icon")]
        public int WeatherIconId { get; set; }


        public WeatherEntity(string city, DateTime date,int temperature, int humidity, int windSpeed,string iconDesc,int icon)
        {
            City = city;          
            Date = date;          
            Temperature = temperature;
            Humidity = humidity;
            WindSpeed = windSpeed;
            WeatherIconDesc = iconDesc;
            WeatherIconId = icon;
        }
    }
}
