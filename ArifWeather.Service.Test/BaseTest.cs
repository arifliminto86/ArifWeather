using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ArifWeather.Model;
namespace ArifWeather.Service.Test
{
    [TestClass]
    public class BaseTest
    {
        protected User _currentUser;

        public BaseTest()
        {
            _currentUser = new User()
            {
                UserName = "arifliminto86", 
                Password = "Bingo123"
            };
        }
    }
}
