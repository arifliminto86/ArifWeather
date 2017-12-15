using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ArifWeather.Model;
using RestSharp;

namespace ArifWeather.Service.Service
{
    public class LocationService : BaseService, ILocationService
    {
        private const string Requestheader = @"locations/v1";

        public LocationService(User user, string apiUrl) : base(user, apiUrl){}

        public List<Country> GetCountries(string regionCode)
        {            
            string restRequest = $@"{Requestheader}/countries/{regionCode}";
            var request =  BuildGetRequest(restRequest, Method.GET);           
            var countries = RestClient.Execute<List<Country>>(request);

            if(!countries.Data.Any())
            {
                throw new ArgumentException($@"Invalid Region Code: {regionCode}");
            }
            return countries.Data;
        }

        public List<LocationKey> GetCityLocationKeys(string city)
        {
            string restRequest = $@"{Requestheader}/cities/search";

            var parameters = new List<Parameter>
            {
                new Parameter
                {
                    Name = "q",
                    Value = city.ToLower(),                    
                    Type =   ParameterType.QueryString
                }
            };
            var request = BuildGetRequest(restRequest, Method.GET, parameters);

            var locations = RestClient.Execute<List<LocationKey>>(request);

            if (locations.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NullReferenceException($@"Cannot find city : {city}");
            }
            return locations.Data;
        }

        public List<City> GetCitiesBasedOnCountry(string countryCode)
        {
            return City.Cities.Where(w => w.CountryCode == countryCode).ToList();
        }        
    }
}
