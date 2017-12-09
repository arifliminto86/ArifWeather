
using ArifWeather.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArifWeather.Service.Test
{
    [TestClass]
    public class WeatherServiceTest : BaseTest
    {
        private readonly IWeatherService _weatherService;

        public WeatherServiceTest()
        {
            _weatherService = new WeatherService(CurrentUser, DefaultUrl);
        }

        [TestMethod]
        public void TestCurrentConditions()
        {
            _weatherService.GetCurrentConditionsAsync();
        }
    }
}