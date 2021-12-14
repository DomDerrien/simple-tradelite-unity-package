using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Web;

using UnityEngine;
using UnityEngine.Networking;

using Tradelite.SDK.DAO;
using Tradelite.SDK.Model.UserScope;

namespace Tradelite.SDK.DAO.UserScope
{

    public class AuthenticationHttpDao : HttpDao<Credentials>
    {
        public AuthenticationHttpDao(string baseUrl): base(baseUrl) {}

        public override Task<Credentials> Get(string id, Hashtable parameters)
        {
            throw new InvalidOperationException("Unsupported operation");
        }

        public override Task<Credentials[]> Select(Hashtable parameters)
        {
            throw new InvalidOperationException("Unsupported operation");
        }

        public override async Task<string> Create(Credentials entity)
        {
            string url = composeUrl(baseUrl, "post");

            // curl \
            //  -k \
            //  -X POST \ 
            //  -d "username=test@email.com&password=x&grant_type=password" \
            //  -H "Content-Type: application/x-www-form-urlencoded" \
            //  -H "Authorization: Basic <username:password>" \
            //  https://int.midas-trader.net/bw-oauth/oauth/token

            try
            {
                WWWForm form = new WWWForm();
                form.AddField("username", entity.username);
                form.AddField("password", entity.password);
                form.AddField("grant_type", entity.grant_type);

                UnityWebRequest request = UnityWebRequest.Post(url, form);
                setRequestHeaders(request);
                signRequest(request);
                // Be sure to set the <form/> type instead of the default `application/json`
                request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

                var operation = request.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Failed: {request.error}");
                }
                else if (request.responseCode == 200) // OK
                {
                    string jsonPayload = request.downloadHandler.text;

                    AuthorizationResponse fullToken = JsonUtility.FromJson<AuthorizationResponse>(jsonPayload);
                    entity.fullToken = fullToken;

                    return entity.fullToken.access_token;
                }

            }
            catch (Exception ex)
            {
                Debug.LogError($"A failed with message: {ex.Message}");
            }

            return default;
        }
    }

}