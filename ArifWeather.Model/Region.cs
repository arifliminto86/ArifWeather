using System.Threading.Tasks;
using System.Collections.Generic;

namespace ArifWeather.Model
{
    public class Region
    {        
        public string ID{ get; set; }

        public string LocalizedName { get; set; }

        public string EnglishName { get; set; }

        public Region()
        {
            //nothing to do
        }

        public Region(string regionId, string localizedName, string englishName)
        {
            ID = regionId;
            LocalizedName = localizedName;
            EnglishName = englishName;
        }

        public static List<Region> GetDefaultRegions()
        {
           
            return new List<Region>()
            {
                new Region("AFR","Africa","Africa"),
                new Region("ANT","Antarctica","Antarctica"),
                new Region("ARC","Arctic","Arctic"),
                new Region("ASI","Asia","Asia"),
                new Region("CAC","Central America", "Central America"),
                new Region("EUR","Europe","Europe"),
                new Region("MEA","Middle East","Middle East"),
                new Region("NAM","North America","North America"),
                new Region("OCN","Oceania","Oceania"),
                new Region("SAM","South America","South America")
            };

            //Task.Run()
        }

    }
}
