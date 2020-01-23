using System;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Net;

namespace WeatherAPI.Client
{

    /// <summary>
    /// implemented Restsharp to have api calls even when we have default .net httpclient 
    /// to explore the features of restssharp 
    /// </summary>
    public class BaseClient : RestSharp.RestClient
    {
        protected string baseUrl = "";
        protected string apiKey = "";
        string ErrorMessage = string.Empty;
        private IConfiguration _configuration;
        protected ICacheService _cache;


        public BaseClient(IConfiguration configuration, ICacheService cache)
        {
            apiKey = configuration.GetSection("Keys:WeatherApiKey").Value;
            baseUrl = configuration.GetSection("Urls:WeatherApiUrl").Value;
            _configuration = configuration;
            _cache = cache;
            BaseUrl = new Uri(baseUrl);
        }

       
        /// <summary>
        /// get response from api based on request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public override IRestResponse<T> Execute<T>(IRestRequest request)
        {
            var response = base.Execute<T>(request);            
            return response;
        }

       
        /// <summary>
        /// Get Response from open weather api using rest sharp client 
        /// or from cache if the key exist in cache 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public T GetFromCache<T>(IRestRequest request, string cacheKey) where T : class, new()
        {
            try
            {

                var item = _cache.Get<T>(cacheKey);
                if (item == null)
                {
                    var response = Execute<T>(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Data != null && !response.Content.Contains("Error"))
                    {
                        _cache.Set(cacheKey, response.Data, 30);
                        item = response.Data;
                    }
                    else
                    {
                        ErrorMessage = response.Content;
                        throw new ApplicationException(ErrorMessage, null);
                    }
                }
                return item;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }

}
