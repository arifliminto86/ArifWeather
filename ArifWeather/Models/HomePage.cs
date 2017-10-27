using System.Threading.Tasks;
using ArifWeather.Model;
using ArifWeather.Service;

namespace ArifWeather.Models
{
    public class HomePage : BasePage
    {
        public TemperatureSearch TemperatureSearch { get; set; }

        public HomePage() : base()
        {          
            //nothing to do
        }

    }
}