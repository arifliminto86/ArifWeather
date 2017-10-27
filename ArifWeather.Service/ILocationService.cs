using System.Collections.Generic;
using ArifWeather.Model;

namespace ArifWeather.Service
{
    public interface ILocationService
    {        
        List<City> GetCitiesBasedOnCountry(string countryCode);

        List<LocationKey> GetCityLocationKeys(string city);

        /// <summary>
        /// Get list of countries based on the region
        /// </summary>
        /// <param name="regionCode"></param>
        /// <returns></returns>
        List<Country> GetCountries(string regionCode);        
    }
}
