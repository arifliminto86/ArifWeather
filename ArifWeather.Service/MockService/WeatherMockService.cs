using System;
using System.Threading.Tasks;
using ArifWeather.Model;

namespace ArifWeather.Service.MockService
{
    public class WeatherMockService : BaseMockService, IWeatherService
    {
        public Weather SunnyWeather => new Weather
        {
            IsDayTime = true,
            LocalObservationDateTime = DateTime.Now.ToLongDateString(),
            Temperature = new Temperature
            {
                Imperial = new Metric { Unit = "celcius", UnitType = 1, Value = 20.0 },
                Metric = new Metric { Unit = "celcius", UnitType = 1, Value = 23.3 }
            },
            WeatherIcon = 2,
            WeatherText = "Raining"
        };

        public WeatherMockService(User user) : base(user){}

        public async Task<Weather> GetCurrentConditionsAsync(string locationKey = "")
        {
            return SunnyWeather;
        }     
    }
}
