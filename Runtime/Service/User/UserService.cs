using System;
using System.Collections;
using System.Threading.Tasks;

using Tradelite.SDK.DAO.UserScope;
using Tradelite.SDK.Model.UserScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.UserScope
{
    public class UserService : BaseService<User>
    {
        private static UserService INSTANCE = null;

        public static UserService GetInstance(Boolean forceReload = false)
        {
            if (INSTANCE == null || forceReload)
            {
                INSTANCE = new UserService();
            }
            return INSTANCE;
        }

        private UserService() : base()
        {
            dao = new UserDao();
        }
    }
}