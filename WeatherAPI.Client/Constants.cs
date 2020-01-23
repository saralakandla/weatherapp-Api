
namespace WeatherAPI.Client
{
    static class Constants
    {
        public const string CityURL = "/forecast?q={0}&APPID={1}&units=metric";
        public const string ZipURL = "/forecast?zip={0}&APPID={1}&units=metric";
        public const string WeatherCityURL = "/weather?q={0}&APPID={1}&units=metric";
        public const string WeatherZipURL = "/weather?zip={0}&APPID={1}&units=metric";
        public const string CachcekeyUniqueZip = "zip_";
        public const string CachcekeyUniqueCity = "city_";
        public const string CachekeyUniqueCurrent = "_Current";
        
    }
}
