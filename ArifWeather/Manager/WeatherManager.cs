using System;
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

        public async Task<HomePage> GenerateHomePage()
        {
            var homepage = new HomePage {CurrentUser = _userService.GetCurrentUser()};

            //TODO: asynch also 
            var currentConditions = await _weatherService.GetCurrentConditionsAsync();
            var region = Region.GetDefaultRegions();
 
            var currentConditionResults = currentConditions;
            homepage.CurrentWeatherInfo.CurrentTemperature = currentConditionResults.Temperature.Metric.Value;
            homepage.CurrentWeatherInfo.CurrentWeatherIconUrl = ControllerHelper.GetWeatherIconUrl(currentConditionResults.WeatherIcon);
            homepage.TemperatureSearch = new TemperatureSearch {Regions = region};

            return homepage;
        }

        public List<City> GetCitiesBasedOnCountry(string countryCode)
        {
            return _locationService.GetCitiesBasedOnCountry(countryCode);
        }

        public List<LocationKey> GetCityLocationKeys(string city)
        {
            return _locationService.GetCityLocationKeys(city);
        }

        public List<Country> GetCountries(string regionCode)
        {
            return _locationService.GetCountries(regionCode);
        }

        public TemperatureSearchResult GetForecastApi(string locationKey)
        {
            return _weatherService.GetForecastApi(locationKey);
        }
    }
}