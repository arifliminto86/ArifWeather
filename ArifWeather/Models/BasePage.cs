using ArifWeather.Model;

namespace ArifWeather.Models
{
    public class BasePage
    {
        public CurrentInfo CurrentWeatherInfo { get; set; }

        public string CurrentPage { get; set; }

        public User CurrentUser { get; set; }

        public BasePage()
        {
            CurrentWeatherInfo = new CurrentInfo();
        }
    }
}