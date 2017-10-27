using ArifWeather.Model;

namespace ArifWeather.Service
{
    public class UserService : BaseService, IUserService
    {
        public UserService(User user) : base(user)
        {
            //nothing to do yet
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }
    }
}
