namespace ArifWeather.Model
{
    public class Wind
    {
        public Metric Speed { get; set; }
        public Direction Direction { get; set; }
    }

    public class Direction
    {
        public double Degrees { get; set; }
        public string Localized { get; set; }
        public string English { get; set; }
    }
    
}
