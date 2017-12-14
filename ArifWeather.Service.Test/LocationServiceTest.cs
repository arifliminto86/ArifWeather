using System;
using ArifWeather.Model;
using ArifWeather.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArifWeather.Service.Test
{
    [TestClass]
    public class LocationServiceTest : BaseTest
    {
        private readonly ILocationService _locationService;
                
        public LocationServiceTest()
        {
            _locationService = new LocationService(CurrentUser, DefaultUrl);
        }

        [TestMethod]
        public void TestGetCountries()
        {
            var countries = _locationService.GetCountries("AFR");

            Assert.IsNotNull(countries);
        }

        [TestMethod]
        public void TestGetLocationCodes()
        {
            var locationcode = _locationService.GetCityLocationKeys("Perth");
            Assert.IsNotNull(locationcode[0].Key);

        }
    }
}
