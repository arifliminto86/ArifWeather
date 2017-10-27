namespace ArifWeather.Model
{
    /// <summary>
    /// Class to search location key based on any of those fields
    /// </summary>
    public class Location
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }        
    }
}
