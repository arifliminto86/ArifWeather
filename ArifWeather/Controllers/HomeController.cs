using System;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using ArifWeather.Helper;
using ArifWeather.Manager;
namespace ArifWeather.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IWeatherManager weatherManager) : base(weatherManager)
        {
            WeatherManager = weatherManager;
        }

        /// <summary>
        /// Will be cache for 1 hour
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration =3600, VaryByParam ="none")]
        public async Task<ActionResult> Index()
        {
            var page = await WeatherManager.GenerateHomePage();
            
            ViewBag.RegionViewBags = ControllerHelper.GetRegionListItems(page.TemperatureSearch.Regions);            
            return View(page);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Arif Weather use ACCUWEATHER API to get all the temperatures.";            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        
        /// <summary>
        /// Get countries based on region key
        /// </summary>
        /// <param name="regionKey"></param>
        /// <returns></returns>       
        public JsonResult GetCountries(string regionKey)
        {
            var countries = WeatherManager.GetCountries(regionKey);
            return Json(countries,JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetCities(string countryCode)
        {
            var cities = WeatherManager.GetCitiesBasedOnCountry(countryCode);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSearchResult(string city)
        {
            var cities = WeatherManager.GetCityLocationKeys(city);
            
            if(cities.Any())
            {
                string locationKey = cities.First().Key;
                var result = WeatherManager.GetCurrentConditionsAsync(locationKey).Result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            throw new ArgumentNullException($"City {city} is empty/not found ");
        }
    }
}