using System.Collections.Generic;
using System.Web.Mvc;
using System.Reflection;

using ArifWeather.Model;
namespace ArifWeather.Helper
{
    public static class ControllerHelper
    {
        private static readonly string DefaultWeatherIconUrl = @"https://developer.accuweather.com/sites/default/files/";

        /// <summary>
        /// Change collection of regions to viewbagregion
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static List<SelectListItem> GetRegions(List<Region> regions)
        {
            var result = new List<SelectListItem>();

            foreach(var region in regions)
            {
                result.Add(new SelectListItem() { Text = region.LocalizedName, Value = region.ID });
            }
            return result;

        }

        public static string GetWeatherIconUrl(int weatherIcon)
        {
            var url = string.Empty;

            url = weatherIcon > 10 
                ? $"{DefaultWeatherIconUrl}/{weatherIcon}-s.png" 
                : $"{DefaultWeatherIconUrl}/0{weatherIcon}-s.png";

            return url;
        }

        public static string GetVersionNumber()
        {
            return Assembly.GetCallingAssembly().GetName().Version.ToString();            
        }
    }
}