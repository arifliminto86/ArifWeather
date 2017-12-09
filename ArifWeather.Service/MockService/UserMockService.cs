using ArifWeather.Model;

namespace ArifWeather.Service.MockService
{
    public class UserMockService : BaseMockService, IUserService
    {
        public UserMockService(User user) : base(user){}

        public User GetCurrentUser()
        {
            return CurrentUser;
        }
    }
}
