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
        /// For temporary, use this hardcode one 
        /// because accuweather doesnt support get cities from country  code
        /// </summary>
        public static List<City> Cities => new List<City>
        {
            new City("Luanda", "AO"), //AO is angola country code (Africa)
            new City("Huambo","AO"),

            new City("Narsaq","GL"), //GL is greenland country code (ARTIC)
            new City("Nuuk", "GL"),

            new City("Kabul", "AF"), //AF is afganistan (Asia)
            new City("Herat", "AF"),
            new City("Beijing", "CN"), //CN is china country code
            new City("Nanjing","CN"),
            new City("Shanghai", "CN"),

            new City("Swetes","AG"), //ag is antigua and barbuda country code (central america)
            new City("Bolands","AG"),
            
            new City("Arinsal","AD"), //AD is andora country code (Europe)
            new City("Canillo","AD"),

            new City("Dubai","AE"),//AE is united arab (middle east)
            new City("Fujairah", "AE"),
            new City("Jerusalem","IL"),//IL is israel
            new City("Tiberias","IL"),
            new City("Nazareth","IL"),

            new City("Hamilton","BM"),//bm is bermuda
            new City("Toronto","CA"), //CA is canada
            new City("Victoria", "CA"),
            new City("Vancouver","CA"),
            new City("Chicago","US"), //us is isa
            new City("Austin","US"),
            new City("New York", "US"),
            new City("Boston", "US"),

            new City("Perth","AU"), //AU is australia country code
            new City("Melbourne","AU"),
            new City("Sydney","AU"),
            new City("Adelaide","AU"),
            new City("Brisbane","AU"),
            new City("Lami","FJ"), //FJ is fiji country code
            new City("Labasa","FJ"),
            new City("Nasinu","FJ"),
            new City("Auckland","NZ"), //nz is new zealand country code
            new City("Chirstchurch","NZ"),
            new City("Wellington","NZ"),

            new City("Salta","AR"), //AR is argentina
            new City("Mendoza","AL"),
            new City("Salvador","BR"), //BR is brazil
            new City("San Paulo", "BR")
        };
    }

    
}
