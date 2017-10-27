using System;

namespace ArifWeather.Model
{
    public class TemperatureSearchResult
    {
        public Headline Headline { get; set; }
        public DailyForecasts DailyForecasts { get; set; }
        public ForeCast Day { get; set; }
        public ForeCast Night { get; set; }
    }

    public class Headline
    {
        public DateTime EffectiveDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; } //Summary
        public string Category { get; set; }        
    }

    public class DailyForecasts
    {
        public TemperatureForeCast Temperature { get; set; }
    }

    public class TemperatureForeCast
    {
        public Metric Minimum { get; set; }
        public Metric Maximum { get; set; }
    }   
}
