#define LOCAL_DEV_HOST

using Tradelite.SDK.Model.ConfigScope;
using Tradelite.SDK.Model.UserScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.UserScope
{
    public class UserService: BaseService<User>
    {
        private static UserService INSTANCE = null;

        public static UserService GetInstance(GameConfiguration config, string token)
        {
            if (INSTANCE == null)
            {
                INSTANCE = new UserService(config, token);
            }
            return INSTANCE;
        }

        private UserService(GameConfiguration config, string token) : base(config.GetEndpoint("user"), token) {}
    }
}