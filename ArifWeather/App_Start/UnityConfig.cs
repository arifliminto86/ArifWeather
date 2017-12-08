using System;
using System.Web.Mvc;
using System.Configuration;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using ArifWeather.Model;
using ArifWeather.Service;
using ArifWeather.Helper;
using ArifWeather.Manager;
using ArifWeather.Service.MockService;
using ArifWeather.Service.Service;

namespace ArifWeather
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            var isMock = ConfigurationManager.AppSettings["IsMock"].ToString();
            if (isMock == null) throw new InvalidOperationException("Configuration is not right");

            var user = new User()
            {
                UserName = ConfigurationManager.AppSettings["UserName"].ToString(),
                Password = User.DecryptWord(ConfigurationManager.AppSettings["EncryptedWord"].ToString()),
                IsMock = Convert.ToBoolean(isMock),
                Version = ControllerHelper.GetVersionNumber()
            };

            if (!user.IsMock)
            {                
                container.RegisterType<ILocationService, LocationService>(new InjectionConstructor(user));
                container.RegisterType<IWeatherService, WeatherService>(new InjectionConstructor(user));
                container.RegisterType<IUserService, UserService>(new InjectionConstructor(user));
            }
            else if(user.IsMock)
            {
                container.RegisterType<ILocationService, LocationMockService>(new InjectionConstructor(user));
                container.RegisterType<IWeatherService, WeatherMockService>(new InjectionConstructor(user));
                container.RegisterType<IUserService, UserMockService>(new InjectionConstructor(user));
            }
            else
            {
                throw new InvalidOperationException("Configuration is not right");
            }

            container.RegisterType<IWeatherManager, WeatherManager>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}