using ArifWeather.Model;

namespace ArifWeather.Service.MockService
{
    public class BaseMockService
    {
        protected User CurrentUser;

        public BaseMockService(User user)
        {
            CurrentUser = user;
        }
    }
}
