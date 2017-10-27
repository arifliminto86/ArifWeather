namespace ArifWeather.Model
{
    public class Weather
    {
        public string LocalObservationDateTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool IsDayTime { get; set; }
        public Temperature Temperature { get; set; }
    }
}
