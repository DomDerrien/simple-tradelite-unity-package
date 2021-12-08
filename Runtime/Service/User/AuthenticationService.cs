using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

using Tradelite.SDK.DAO.UserScope;
using Tradelite.SDK.Model;
using Tradelite.SDK.Model.ConfigScope;
using Tradelite.SDK.Model.UserScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.UserScope
{
    public class AuthenticationService: BaseService<Credentials>
    {
        private static AuthenticationService INSTANCE = null;

        public static AuthenticationService GetInstance(GameConfiguration gameConfig, bool forceReload = false)
        {
            if (INSTANCE == null || forceReload)
            {
                INSTANCE = new AuthenticationService(gameConfig);
            }
            return INSTANCE;
        }

        private AuthorizationResponse fullToken;

        private AuthenticationService(GameConfiguration gameConfig): base(null, gameConfig)
        {
            // Override of the default HttpDao<Credentials> b/c the `Create()` method has a unique process
            Debug.Log("111 " + dao);
            dao = new AuthenticationHttpDao(gameConfig.GetEndpoint("authentication"));
            Debug.Log("222 " + dao);
        }

        public async Task<string> Authenticate(string username, string password) 
        {
            Credentials creds = new Model.UserScope.Credentials();
            creds.username = username;
            creds.password = password;
            Debug.Log("333 " + dao);
            token = await dao.Create(creds);
            fullToken = creds.fullToken;
            return token;
        }

        public async void Authenticate(string username, string password, Action<string> success, Action<BaseError> failure)
        {
            try
            {
                success?.Invoke(await Authenticate(username, password));
            }
            catch (Exception ex)
            {
                failure?.Invoke(new BaseError($"Cannot authenticate user with username: {username}", ex));
            }
        }

        public async Task<User> GetLoggedUser() {
            return await (UserService.GetInstance(gameConfig, fullToken.access_token)).Get(fullToken.id + "");
        }

        public override Task<Credentials> Get(string id, Hashtable parameters = null) 
        {
            throw new InvalidOperationException("Not supported!");
        }

        public override Task<Credentials[]>Select(Hashtable parameters = null) 
        {
            throw new InvalidOperationException("Not supported!");
        }

        public override Task<string> Create(Credentials entity) 
        {
            throw new InvalidOperationException("Not supported!");
        }
    }
}
