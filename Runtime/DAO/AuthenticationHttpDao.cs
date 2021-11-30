using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Web;

using UnityEngine;
using UnityEngine.Networking;

using Tradelite.SDK.Model.UserScope;

namespace Tradelite.SDK.DAO
{

    public class AuthenticationHttpDao : HttpDao<Credentials>
    {
        public AuthenticationHttpDao(string baseUrl): base(baseUrl) {}

        public new Task<Credentials> Get(string id, Hashtable parameters)
        {
            throw new InvalidOperationException("Unsupported operation");
        }

        public new Task<Credentials[]> Select(Hashtable parameters)
        {
            throw new InvalidOperationException("Unsupported operation");
        }

        public new async Task<string> Create(Credentials entity)
        {
            string url = baseUrl + ".json";

            try
            {
                string payload = JsonUtility.ToJson(entity);

                UTF8Encoding encoder = new UTF8Encoding();
                byte[] encodedPayload = encoder.GetBytes(payload);
                
                UploadHandler uploader = new UploadHandlerRaw(encodedPayload);
                uploader.contentType = "application/json";

                UnityWebRequest request = new UnityWebRequest(url, "POST");
                setRequestHeaders(request, true);
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
                else if (request.responseCode == 200) // OK
                {
                    string token = request.downloadHandler.text;

                    return token;
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