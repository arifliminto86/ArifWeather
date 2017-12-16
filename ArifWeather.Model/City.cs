using System.Collections.Generic;
namespace ArifWeather.Model
{
    public class City
    {
        public string Name{get;set;}
        public Country Country { get; set; }
        public string CountryCode { get; set; }
        public LocationKey LocationKey { get; set; }

        /// <summary>
        /// Default ctor
        /// </summary>
        public City()
        {
            //nothing to do
        }

        /// <summary>
        /// Custom Ctor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="countryCode"></param>
        public City(string name, string countryCode)
        {
            Name = name;
            CountryCode = countryCode;
        }

        /// <summary>
        /// For temporary, use this one because accuweather doesnt support get cities from country  code
        /// </summary>
        public static List<City> Cities
        {
            get
            {
                return new List<City>
                {
                    new City("Perth","AU"),
                    new City("Melbourne","AU"),
                    new City("Sydney","AU"),
                    new City("Adelaide","AU"),
                    new City("Brisbane","AU"),
                    new City("Lami","FJ"),
                    new City("Labasa","FJ"),
                    new City("Nasinu","FJ"),
                    new City("Auckland","NZ"),
                    new City("Chirstchurch","NZ"),
                    new City("Wellington","NZ")
                };
            }
        }
    }

    
}
