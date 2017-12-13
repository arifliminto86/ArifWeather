using System.Collections.Generic;
using ArifWeather.Model;

namespace ArifWeather.Service
{
    public interface ILocationService
    {        
        /// <summary>
        /// Get all cities in one country
        /// </summary>
        /// <param name="countryCode">country code</param>
        /// <returns></returns>
        List<City> GetCitiesBasedOnCountry(string countryCode);

        List<LocationKey> GetCityLocationKeys(string city);

        /// <summary>
        /// Get list of countries based on the region
        /// </summary>
        /// <param name="regionCode">the region code</param>
        /// <returns></returns>
        List<Country> GetCountries(string regionCode);        
    }
}
