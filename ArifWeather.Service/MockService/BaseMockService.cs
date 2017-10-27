
using ArifWeather.Model;
namespace ArifWeather.Service
{
    public class BaseMockService
    {
        protected User _currentUser;

        public BaseMockService(User user)
        {
            _currentUser = user;
        }
    }
}
