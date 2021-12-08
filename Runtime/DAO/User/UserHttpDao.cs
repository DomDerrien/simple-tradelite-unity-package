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
    class UserForCreation
    {
        public string email;
        public string password;
        public string birthday;
        public string firstname;
        public string lastname;
        public string maidenname;
        public string nickname;
        public string dateAcceptConditions;
        public string acceptConditionsVersion;
        public bool ageVerification;
        public bool mobile;
        public string tenantId;

        public UserForCreation From(User user)
        {
            this.email = user.email;
            this.password = user.password;
            this.birthday = user.birthday;
            this.firstname = user.firstname;
            this.lastname = user.lastname;
            this.maidenname = user.maidenname;
            this.nickname = user.nickname;
            this.dateAcceptConditions = user.dateAcceptConditions;
            this.acceptConditionsVersion = user.acceptConditionsVersion;
            this.ageVerification = user.ageVerification;
            this.mobile = user.mobile;
            this.tenantId = user.tenantId;
            return this;
        }
    }

    public class UserHttpDao : HttpDao<User>
    {
        public UserHttpDao(string baseUrl, string authToken = null): base(baseUrl, authToken) {}

        public override Task<User[]> Select(Hashtable parameters)
        {
            throw new InvalidOperationException("Unsupported operation");
        }

        public override async Task<string> Create(User entity)
        {
            string url = composeUrl(baseUrl);

            // curl \
            //   --location
            //   --request POST \
            //   --header 'Authorization: Bearer <JWT token>>' \
            //   --header 'Content-Type: application/json' \
            //   --data-raw '{ <user-details> }' \
            //   'https://int.tradelite.net/user-management/v1.0/user'

            try
            {
                string payload = JsonUtility.ToJson((new UserForCreation()).From(entity));

                UTF8Encoding encoder = new UTF8Encoding();
                byte[] encodedPayload = encoder.GetBytes(payload);
                
                UploadHandler uploader = new UploadHandlerRaw(encodedPayload);
                uploader.contentType = "application/json";

                UnityWebRequest request = new UnityWebRequest(url, "POST");
                setRequestHeaders(request);
                request.uploadHandler = uploader;
                request.downloadHandler = new DownloadHandlerBuffer();

                var operation = request.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Failed: {request.error}");
                }
                else if (request.responseCode == 201) // OK
                {
                    string jsonPayload = request.downloadHandler.text;

                    User output = JsonUtility.FromJson<User>(jsonPayload);

                    return output.id;
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