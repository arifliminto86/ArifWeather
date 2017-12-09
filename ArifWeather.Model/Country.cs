
namespace ArifWeather.Model
{
    public class Country
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }

        public Country() { }

        public Country(LocationKey locationKey)
        {
            ID = locationKey.Key;
            LocalizedName = locationKey.Name;
            EnglishName = locationKey.Name;
        }
    }
}
