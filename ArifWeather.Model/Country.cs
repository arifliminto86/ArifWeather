
namespace ArifWeather.Model
{
    public class Country
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }

        /// <summary>
        /// Default ctor
        /// </summary>
        public Country() { }

        /// <summary>
        /// Custom Ctor
        /// </summary>
        /// <param name="locationKey">the location key</param>
        public Country(LocationKey locationKey)
        {
            ID = locationKey.Key;
            LocalizedName = locationKey.Name;
            EnglishName = locationKey.Name;
        }
    }
}
