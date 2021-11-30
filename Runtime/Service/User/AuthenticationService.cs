using System.Threading.Tasks;

using Tradelite.SDK.DAO;
using Tradelite.SDK.Model.ConfigScope;
using Tradelite.SDK.Model.UserScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.UserScope
{
    public class AuthenticationService
    {
        private static AuthenticationService INSTANCE = null;

        public static AuthenticationService GetInstance(GameConfiguration config)
        {
            if (INSTANCE == null)
            {
                INSTANCE = new AuthenticationService(config);
            }
            return INSTANCE;
        }

        private string token;
        private AuthenticationHttpDao dao;

        private AuthenticationService(GameConfiguration config) 
        {
            dao = new AuthenticationHttpDao(config.GetEndpoint("authentication"));
        }

        public async Task<string> Authenticate(string username, string password) 
        {
            Credentials creds = new Model.UserScope.Credentials();
            creds.username = username;
            creds.password = password;
            token = await dao.Create(creds);
            return token;
        }
    }
}
