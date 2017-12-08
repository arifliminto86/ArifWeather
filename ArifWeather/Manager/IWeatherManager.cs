
using System.Threading.Tasks;
using System.Collections.Generic;
using ArifWeather.Model;
using ArifWeather.Models;

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

        Task<TemperatureSearchResult> GetForecastApi(string locationKey);

    }
}
