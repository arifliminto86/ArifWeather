using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ArifWeather.Model;

namespace ArifWeather.Models
{
    public class TemperatureSearch
    {
        /// <summary>
        /// List of regions in the world
        /// </summary>        
        public List<Region> Regions { get; set; }

        /// <summary>
        /// List of countries in one region
        /// </summary>        
        public List<Country> Countries { get; set; }

        /// <summary>
        /// List of cities in one countries
        /// At the moment, it is hard code
        /// </summary>
        [Required]
        public List<string> Cities { get; set; }
        
        /// <summary>
        /// Search result giving the input query
        /// </summary>
        public Weather SearchResult { get; set; }
    }
}