using System;
using ArifWeather.Model;
using ArifWeather.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArifWeather.Service.Test
{
    [TestClass]
    public class LocationServiceTest : BaseTest
    {
        private ILocationService _locationService;
                
        public LocationServiceTest()
        {
            
            _locationService = new LocationService(_currentUser);
        }

        [TestMethod]
        public void TestGetCountries()
        {
            var countries = _locationService.GetCountries("AFR");

            Assert.IsNotNull(countries);
        }

    }
}
