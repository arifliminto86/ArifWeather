using System.Threading.Tasks;
using ArifWeather.Model;

namespace ArifWeather.Service
{
    public interface IWeatherService
    {
        Task<Weather> GetCurrentConditionsAsync(string locationKey = "");

        TemperatureSearchResult GetForecastApi(string locationKey);     
    }
}
