
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
        /// <summary>
        /// function to generate home page model
        /// </summary>
        /// <returns>task of home page model</returns>
        Task<HomePage> GenerateHomePage();

        /// <summary>
        /// get all cities based on country
        /// TODO: at the moment, it is hard code, havent found time/api yet
        /// </summary>
        /// <param name="countryCode">the country code</param>
        /// <returns>list of cities</returns>
        List<City> GetCitiesBasedOnCountry(string countryCode);

        /// <summary>
        /// Get location key of the city
        /// </summary>
        /// <param name="city">city that we are looking for</param>
        /// <returns>list of location keys</returns>
        List<LocationKey> GetCityLocationKeys(string city);

        /// <summary>
        /// Get list of countries based on the region
        /// </summary>
        /// <param name="regionCode">the region code</param>
        /// <returns>list of country</returns>
        List<Country> GetCountries(string regionCode);

        /// <summary>
        /// Get current weather condition based on location code
        /// </summary>
        /// <param name="locationCode">the location code</param>
        /// <returns>the current weather condition</returns>
        Weather GetCurrentConditions(string locationCode);        
    }
}
