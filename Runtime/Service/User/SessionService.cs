using System;
using System.Collections;
using System.Threading.Tasks;

using Tradelite.SDK.DAO.UserScope;
using Tradelite.SDK.Model.UserScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.UserScope
{
    public class SessionService
    {
        private static SessionService INSTANCE = null;

        public static SessionService GetInstance(Boolean forceReload = false)
        {
            if (INSTANCE == null || forceReload)
            {
                INSTANCE = new SessionService();
            }
            return INSTANCE;
        }

        private Session session;

        private SessionService() : base()
        {
            session = new Session();
        }

        public void SetLocale(String locale = "en")
        {
            session.locale = locale;
        }
    }
}