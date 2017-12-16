using System.Threading.Tasks;
using ArifWeather.Model;

namespace ArifWeather.Service
{
    public interface IWeatherService
    {
        /// <summary>
        /// Get current conditions async
        /// </summary>
        /// <param name="locationKey">the city location key</param>
        /// <returns></returns>
        Task<Weather> GetCurrentConditionsAsync(string locationKey = "");

        /// <summary>
        /// Get non async current conditions
        /// </summary>
        /// <param name="locationKey">the city location key</param>
        /// <returns></returns>
        Weather GetCurrentConditions(string locationKey = "");
    }
}
