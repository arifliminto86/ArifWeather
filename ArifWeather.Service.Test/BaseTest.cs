using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ArifWeather.Model;
namespace ArifWeather.Service.Test
{
    [TestClass]
    public class BaseTest
    {
        protected User CurrentUser;

        protected string DefaultUrl = @"http://dataservice.accuweather.com";

        public BaseTest()
        {
            CurrentUser = new User()
            {
                UserName = "arifliminto86", 
                Password = "Bingo123"
            };
        }
    }
}
