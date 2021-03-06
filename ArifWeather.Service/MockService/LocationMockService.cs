﻿using System.Collections.Generic;
using System.Linq;
using ArifWeather.Model;

namespace ArifWeather.Service.MockService
{
    public class LocationMockService : BaseMockService, ILocationService
    {
        #region DummyData
        private List<LocationKey> AusieCities => new List<LocationKey>()
        {
            new LocationKey{Country = Australia, Key="1", Rank=5, Type="City", Name = "Perth"},
            new LocationKey{Country = Australia, Key="2", Rank=4, Type="City", Name = "Melbourne"},
            new LocationKey{Country = Australia, Key="3", Rank=3, Type="City", Name = "Sydney"},
            new LocationKey{Country = Australia, Key="4", Rank=2, Type="City", Name = "Brisbane"},
            new LocationKey{Country = Australia, Key="5", Rank=1, Type="City", Name = "Adelaide"},
        };

        private List<Country> OceaniaCountries => new List<Country>
        {
            new Country{ID = "AU", EnglishName="Australia", LocalizedName = "Australia"},
            new Country{ID = "NZ", EnglishName = "New Zealand", LocalizedName = "New Zealand"},
            new Country{ID = "FJ", EnglishName = "Fiji", LocalizedName = "Fiji"},                    
        };

        private List<Country> AfricaCountries => new List<Country>
        {
            new Country { ID="AO", EnglishName = "Angola", LocalizedName = "Angola"}
        };

        #endregion
        public Country Australia => new Country { EnglishName = "Australia", LocalizedName = "Australia", ID = "1" };

        public LocationMockService(User user) : base(user){}

        public List<LocationKey> GetCityLocationKeys(string city)
        {
            return AusieCities;
        }

        public List<Country> GetCountries(string regionCode)
        {
            var countries = new List<Country>();
            if (regionCode == "OCN")
            {
                countries = OceaniaCountries;
            }
            else if (regionCode == "AFR") //africa
            {
                countries = AfricaCountries;
            }
            return countries;
        }

        public List<City> GetCitiesBasedOnCountry(string countryCode)
        {
            return City.Cities.Where(w => w.CountryCode == countryCode).ToList();         
        }
    }
}
