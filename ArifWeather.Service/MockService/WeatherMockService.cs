using System;
using System.Threading.Tasks;
using ArifWeather.Model;

namespace ArifWeather.Service
{
    public class WeatherMockService : BaseMockService, IWeatherService
    {
        public Weather SunnyWeather
        {
            get
            {
                return new Weather()
                {
                    IsDayTime = true,
                    LocalObservationDateTime = DateTime.Now.ToLongDateString(),
                    Temperature = new Temperature()
                    {
                        Imperial = new Metric() { Unit = "celcius", UnitType = 1, Value = 20.0 },
                        Metric = new Metric() { Unit = "celcius", UnitType = 1, Value = 23.3 }
                    },
                    WeatherIcon = 2,
                    WeatherText = "Raining"
                };
            }
        }
        public WeatherMockService(User user) : base(user)
        {

        }

        public async Task<Weather> GetCurrentConditionsAsync(string locationKey = "")
        {
            return SunnyWeather;
        }

        public TemperatureSearchResult GetForecastApi(string locationKey)
        {
            return new TemperatureSearchResult
            {
                Headline = BuildDummyHeadline(),
                DailyForecasts = BuildDummyForecasts(),
                Day = BuildDummyForecastDay(),
                Night = BuildDummyForecastNight()
            };            
        }


        #region DummySearchResult

        private Headline BuildDummyHeadline()
        {
            return new Headline()
            {
                EffectiveDate = DateTime.Now,
                Severity = 4,
                Text = "Pleasant Sunday"            
            };
        }

        private DailyForecasts BuildDummyForecasts()
        {
            return new DailyForecasts()
            {
                Temperature = new TemperatureForeCast()
                {
                    Minimum = new Metric() { Value = 46, Unit = "F", UnitType = 18 },
                    Maximum = new Metric() { Value = 60, Unit = "F", UnitType = 18 }
                }
            };
        }

        private ForeCast BuildDummyForecastDay()
        {
            return new ForeCast()
            {
                Icon= 14,
                IconPhrase = "Partly sunny w/ showers",
                ShortPhrase = "Periods of clouds and sun",
                LongPhrase = "Intervals of clouds and sunshine with a shower in spots this afternoon",
                PrecipitationProbability = 50,
                ThunderstormProbability = 20,
                RainProbability = 49,
                SnowProbability = 0,
                IceProbability = 0,
                Wind = new Wind()
                {
                    Speed = new Metric(){Value=9.2, Unit = "mi/h",UnitType = 9},
                    Direction = new Direction() {Degrees = 230, Localized = "SW",English="SW" }
                },
            };
        }

        private ForeCast BuildDummyForecastNight()
        {
            return new ForeCast()
            {
                Icon = 36,
                IconPhrase = "Intermittent clouds",
                ShortPhrase = "A shower early; partly cloudy",
                LongPhrase = "A stray evening shower; otherwise, partly cloudy",
                PrecipitationProbability = 50,
                ThunderstormProbability = 20,
                RainProbability = 50,
                SnowProbability = 0,
                IceProbability = 0,
                Wind = new Wind()
                {
                    Speed = new Metric() { Value = 4.6, Unit = "mi/h", UnitType = 9 },
                    Direction = new Direction() { Degrees = 355, Localized = "W", English = "W" }
                },
            };
        }
        #endregion
    }
}
