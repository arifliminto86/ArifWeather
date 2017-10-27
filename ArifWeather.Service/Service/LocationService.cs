using System;
using System.Collections.Generic;
using System.Linq;
using ArifWeather.Model;
using RestSharp;

namespace ArifWeather.Service
{
    public class LocationService : BaseService, ILocationService
    {
        private const string requestheader = @"locations/v1";

        public LocationService(User user) : base(user)
        {

        }

        public List<Country> GetCountries(string regionCode)
        {            
            string restRequest = $@"{requestheader}/countries/{regionCode}";
            var request =  BuildGetRequest(restRequest, Method.GET);           
            var countries = _restClient.Execute<List<Country>>(request);

            if(!countries.Data.Any())
            {
                throw new ArgumentException($@"Invalid Region Code: {regionCode}");
            }
            return countries.Data;
        }

        public List<LocationKey> GetCityLocationKeys(string city)
        {
            string restRequest = $@"{requestheader}/cities/autocomplete";
            var parameters = new List<Parameter>
            {
                new Parameter(){Name = "q", Value = city}
            };
            var request = BuildGetRequest(restRequest, Method.GET, parameters);

            var locations = _restClient.Execute<List<LocationKey>>(request);

            if (!locations.Data.Any())
            {
                throw new NullReferenceException($@"Cannot find city : {city}");
            }
            return locations.Data;
        }

        public List<City> GetCitiesBasedOnCountry(string countryCode)
        {
            return City.Cities.Where(w => w.CountryCode == countryCode).ToList();
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }
    }
}
