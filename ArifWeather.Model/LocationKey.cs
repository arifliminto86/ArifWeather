namespace ArifWeather.Model
{
    public class LocationKey
    {
        /// <summary>
        /// Type can be city/ postal code
        /// </summary>
        public string Type { get; set; }

        public string Key { get; set; }

        public int Rank { get; set; }

        public string Name { get; set; }

        public Country Country {get;set;}
    }
}
