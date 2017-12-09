namespace ArifWeather.Model
{
    public class ForeCast
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public string ShortPhrase { get; set; }
        public string LongPhrase { get; set; }
        public double PrecipitationProbability { get; set; }
        public double ThunderstormProbability { get; set; }
        public double RainProbability { get; set; }
        public double SnowProbability { get; set; }
        public double IceProbability { get; set; }
        public Wind Wind { get; set; }
    }
}
