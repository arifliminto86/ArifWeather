using System.Web.Mvc;
using ArifWeather.Manager;

namespace ArifWeather.Controllers
{
    public class BaseController : Controller
    {
        protected IWeatherManager WeatherManager;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="weatherManager">The weather manager</param>
        public BaseController(IWeatherManager weatherManager)
        {
            WeatherManager = weatherManager;
        }
    }
}