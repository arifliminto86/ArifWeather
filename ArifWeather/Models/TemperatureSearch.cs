using System.Collections.Generic;
using ArifWeather.Model;

namespace ArifWeather.Models
{
    public class TemperatureSearch
    {
        public List<Region> Regions { get; set; }
        public List<Country> Countries { get; set; }

        //At the moment, it is hard code
        public List<string> Cities { get; set; }

        public string City { get; set; }        
        public string KeyWord { get; set; }        

        public Weather SearchResult { get; set; }
    }
}