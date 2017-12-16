using System.Collections.Generic;
using System.Threading.Tasks;
using ArifWeather.Helper;
using ArifWeather.Model;
using ArifWeather.Models;
using ArifWeather.Service;

namespace ArifWeather.Manager
{
    public class WeatherManager : IWeatherManager
    {
        private readonly IUserService _userService;
        private readonly IWeatherService _weatherService;
        private readonly ILocationService _locationService;

        public WeatherManager(IUserService userService, IWeatherService weatherService,
                                ILocationService locationService)
        {
            _userService = userService;
            _weatherService = weatherService;
            _locationService = locationService;
        }
        /// <summary>
        /// function to generate home page model
        /// </summary>
        /// <returns>task of home page model</returns>
        public async Task<HomePage> GenerateHomePage()
        {
            var homepage = new HomePage {CurrentUser = _userService.GetCurrentUser()};

            var currentConditions = await _weatherService.GetCurrentConditionsAsync();
            var region = Region.GetDefaultRegions();
 
            var currentConditionResults = currentConditions;
            homepage.CurrentWeatherInfo.CurrentTemperature = currentConditionResults.Temperature.Metric.Value;
            homepage.CurrentWeatherInfo.CurrentWeatherIconUrl = ControllerHelper.GetWeatherIconUrl(currentConditionResults.WeatherIcon);
            homepage.TemperatureSearch = new TemperatureSearch {Regions = region};

            return homepage;
        }
        /// <summary>
        /// get all cities based on country
        /// TODO: at the moment, it is hard code, havent found time/api yet
        /// </summary>
        /// <param name="countryCode">the country code</param>
        /// <returns>list of cities</returns>
        public List<City> GetCitiesBasedOnCountry(string countryCode)
        {
            return _locationService.GetCitiesBasedOnCountry(countryCode);
        }

        /// <summary>
        /// Get location key of the city
        /// </summary>
        /// <param name="city">city that we are looking for</param>
        /// <returns>list of location keys</returns>
        public List<LocationKey> GetCityLocationKeys(string city)
        {
            return _locationService.GetCityLocationKeys(city);
        }

        /// <summary>
        /// Get location key of the city
        /// </summary>
        /// <param name="city">city that we are looking for</param>
        /// <returns>list of location keys</returns>
        public List<Country> GetCountries(string regionCode)
        {
            return _locationService.GetCountries(regionCode);
        }

        /// <summary>
        /// Get current weather condition based on location code
        /// </summary>
        /// <param name="locationCode">the location code</param>
        /// <returns>the current weather condition</returns>
        public Weather GetCurrentConditions(string locationCode)
        {
            var weather =  _weatherService.GetCurrentConditions();
            return weather;
        }
    }
}