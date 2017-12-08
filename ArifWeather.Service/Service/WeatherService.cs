using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RestSharp;
using ArifWeather.Model;
using ArifWeather.Service.Service;

namespace ArifWeather.Service
{
    public class WeatherService : BaseService, IWeatherService
    {
        public WeatherService(User user) : base(user)
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
            //var t = _restClient.ExecuteAsGet<List<Weather>>(request, "GET");
            
            var weather =  RestClient.ExecuteAsync<List<Weather>>(request, restResponse =>
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
      

        public TemperatureSearchResult GetForecastApi(string locationKey)
        {
            throw new NotImplementedException();
        }

        public async Task<TemperatureSearchResult> GetForecastApiAsynch(string locationKey)
        {
            throw new NotImplementedException();
        }
    }
}
