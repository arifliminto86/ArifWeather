
using ArifWeather.Model;
using ArifWeather.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArifWeather.Manager
{
    /// <summary>
    /// All the logic that interact with the services
    /// </summary>
    public interface IWeatherManager
    {
       Task<HomePage> GenerateHomePage();

       List<City> GetCitiesBasedOnCountry(string countryCode);

        List<LocationKey> GetCityLocationKeys(string city);

        /// <summary>
        /// Get list of countries based on the region
        /// </summary>
        /// <param name="regionCode"></param>
        /// <returns></returns>
        List<Country> GetCountries(string regionCode);

        /// <summary>
        /// Get current weather condition based on location code
        /// </summary>
        /// <param name="locationCode">the location code</param>
        /// <returns></returns>
        Task<Weather> GetCurrentConditionsAsync(string locationCode);        
    }
}
