using System;
using System.Collections;
using System.Threading.Tasks;

using Tradelite.SDK.DAO.UserScope;
using Tradelite.SDK.Model;
using Tradelite.SDK.Model.ConfigScope;
using Tradelite.SDK.Model.UserScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.UserScope {
    public class UserService : BaseService<User> {
        private static UserService INSTANCE = null;

        public static UserService GetInstance(GameConfiguration gameConfig, string token, bool forceReload = false) {
            if (INSTANCE == null || forceReload) {
                INSTANCE = new UserService(gameConfig, token);
            }
            return INSTANCE;
        }

        private UserService(GameConfiguration gameConfig, string token) : base(null, gameConfig, token) {
            // Override of the default HttpDao<User> b/c the `Create()` method has a unique process
            dao = new UserHttpDao(gameConfig.GetEndpoint("user"), token);
        }
    }
}