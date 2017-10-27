using System;
using System.Linq;
using System.Collections.Generic;
using ArifWeather.Model;

namespace ArifWeather.Service
{
    public class LocationMockService : BaseMockService, ILocationService
    {
        #region DummyData
        public List<LocationKey> _AusieCities
        {
            get
            {
                return new List<LocationKey>()
                {
                    new LocationKey(){Country = Australia, Key="1", Rank=5, Type="City", Name = "Perth"},
                    new LocationKey(){Country = Australia, Key="2", Rank=4, Type="City", Name = "Melbourne"},
                    new LocationKey(){Country = Australia, Key="3", Rank=3, Type="City", Name = "Sydney"},
                    new LocationKey(){Country = Australia, Key="4", Rank=2, Type="City", Name = "Brisbane"},
                    new LocationKey(){Country = Australia, Key="5", Rank=1, Type="City", Name = "Adelaide"},
                };
            }
        }

        public List<Country> _OceaniaCountries
        {
            get
            {
                return new List<Country>()
                {
                    new Country(){ID = "AU", EnglishName="Australia", LocalizedName = "Australia"},
                    new Country(){ID = "NZ", EnglishName = "New Zealand", LocalizedName = "New Zealand"},
                    new Country(){ID = "FJ", EnglishName = "Fiji", LocalizedName = "Fiji"},                    
                };
            }
        }
        

        #endregion
        public Country Australia
        {
            get
            {
                return new Country() { EnglishName = "Australia", LocalizedName = "Australia", ID = "1" };
            }
        }

        public LocationMockService(User user) : base(user)
        {

        }

        public List<LocationKey> GetCityLocationKeys(string city)
        {
            var countries = new List<Country>();

            return _AusieCities;
        }

        public List<Country> GetCountries(string regionCode)
        {
            var countries = new List<Country>();
            if (regionCode == "OCN")
            {
                countries = _OceaniaCountries;
            }
            return countries;
        }

        public List<City> GetCitiesBasedOnCountry(string countryCode)
        {            
            return City.Cities.Where(w => w.CountryCode == countryCode).ToList();         
        }       
    }
}
