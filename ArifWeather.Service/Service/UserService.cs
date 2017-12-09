using ArifWeather.Model;
using ArifWeather.Service.Service;

namespace ArifWeather.Service
{
    public class UserService : BaseService, IUserService
    {
        public UserService(User user, string apiUrl) : base(user, apiUrl)
        {
            //nothing to do yet
        }

        public User GetCurrentUser()
        {
            return CurrentUser;
        }
    }
}
