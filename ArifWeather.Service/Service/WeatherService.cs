using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArifWeather.Model;
using RestSharp;

namespace ArifWeather.Service.Service
{
    public class WeatherService : BaseService, IWeatherService
    {
        public WeatherService(User user, string apiUrl) : base(user, apiUrl)
        {
        }

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

        public async Task<TemperatureSearchResult> GetForecastApiAsync(string locationKey)
        {
            if (string.IsNullOrEmpty(locationKey))
            {
                locationKey = DefaultLocationKey;
            }
          
            string restRequest = $@"forecasts/v1/daily/1day/{locationKey}";
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<TemperatureSearchResult>>();
            var request = BuildGetRequest(restRequest, Method.GET);

            var temperature = RestClient.ExecuteAsync<TemperatureSearchResult>(request,
                restResponse =>
                {
                    if (restResponse.ErrorException != null)
                    {
                        const string message = "Error retrieving response.";
                        throw new ApplicationException(message, restResponse.ErrorException);
                    }
                    taskCompletionSource.SetResult(restResponse);
                });

            var result = await taskCompletionSource.Task;

            if (result.Data == null)
            {
                throw new ArgumentException($@"Invalid locationKey : {locationKey}");
            }
            return result.Data;

        }
    }
}
