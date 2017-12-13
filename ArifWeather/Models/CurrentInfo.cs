using System;

namespace ArifWeather.Models
{
    public class CurrentInfo
    {
        public string CurrentLocation { get; set; }

        public DateTime CurrentDateTime { get; set; }

        public double CurrentTemperature { get; set; }

        public string CurrentWeatherIconUrl { get; set; }

        /// <summary>
        /// Default ctor (by default, it will set to Perth)
        /// </summary>
        public CurrentInfo()
        {
            CurrentDateTime = DateTime.Now;
            CurrentLocation = "Perth";
        }        
    }
}