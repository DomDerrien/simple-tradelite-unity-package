#define LOCAL_DEV_HOST

using Tradelite.SDK.Model.UserScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.UserScope
{
    public class UserService: BaseService<User>
    {
#if LOCAL_DEV_HOST
        private static string BASE_URL = "http://localhost:8181/api-mocks/v1/users";
#else
        private static string BASE_URL = "https://int.tradelite.net/api/v1/usermanagement/users";
#endif
        private static UserService INSTANCE = new UserService();

        public static UserService GetInstance()
        {
            return INSTANCE;
        }

        private UserService() : base(BASE_URL) {}
    }
}