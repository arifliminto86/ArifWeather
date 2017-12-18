using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArifWeather.Model;
using RestSharp;

namespace ArifWeather.Service.Service
{
    public class WeatherService : BaseService, IWeatherService
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="user">user that can request api</param>
        /// <param name="apiUrl">base api url</param>
        public WeatherService(User user, string apiUrl) : base(user, apiUrl){}

        /// <summary>
        /// Get current conditions async
        /// </summary>
        /// <param name="locationKey">the city location key</param>
        /// <returns></returns>
        public async Task<Weather> GetCurrentConditionsAsync(string locationKey = "")
        {                        
            if (string.IsNullOrEmpty(locationKey))
            {
                locationKey = DefaultLocationKey;
            }

            string restRequest = $@"currentconditions/v1/{locationKey}";
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<List<Weather>>>();
            var request = BuildGetRequest(restRequest, Method.GET);
            
            var weather =  RestClient.ExecuteAsync<List<Weather>>(request, 
            restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    const string message = "Error retrieving response.";
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });

            var weatherResult = await taskCompletionSource.Task;

            if (weatherResult.Data == null)
            {
                throw new ArgumentException($@"Invalid locationKey : {locationKey}");
            }
            return weatherResult.Data[0];
        }
        
        /// <summary>
        /// Get non async current conditions
        /// </summary>
        /// <param name="locationKey">the city location key</param>
        /// <returns></returns>
        public Weather GetCurrentConditions(string locationKey = "")
        {
            if (string.IsNullOrEmpty(locationKey))
            {
                locationKey = DefaultLocationKey;
            }

            string restRequest = $@"currentconditions/v1/{locationKey}";

            var request = BuildGetRequest(restRequest, Method.GET);
            var weather = RestClient.Execute<List<Weather>>(request);

            if (weather.Data == null)
            {
                throw new ArgumentException($@"Invalid locationKey : {locationKey}");
            }
            return weather.Data[0];
        }        
    }
}
