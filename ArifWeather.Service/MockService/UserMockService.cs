
using ArifWeather.Model;
namespace ArifWeather.Service
{
    public class UserMockService : BaseMockService, IUserService
    {
        public UserMockService(User user) : base(user)
        {

        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }
    }
}
