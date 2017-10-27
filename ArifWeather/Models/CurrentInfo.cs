using System;

namespace ArifWeather.Models
{
    public class CurrentInfo
    {
        public string CurrentLocation { get; set; }

        public DateTime CurrentDateTime { get; set; }

        public double CurrentTemperature { get; set; }

        public string CurrentWeatherIconUrl { get; set; }

        public CurrentInfo()
        {
            CurrentDateTime = DateTime.Now;
            CurrentLocation = "Perth";
        }
    }
}