using System.Web.Mvc;
using ArifWeather.Manager;

namespace ArifWeather.Controllers
{
    public class BaseController : Controller
    {
        protected IWeatherManager WeatherManager;

        public BaseController(IWeatherManager weatherManager)
        {
            WeatherManager = weatherManager;
        }
    }
}