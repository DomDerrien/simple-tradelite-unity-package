using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Web;

using UnityEngine;
using UnityEngine.Networking;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.DAO
{

    public class HttpDao<T> : AbstractDao<T> where T : BaseModel
    {
        [Serializable]
        private class EntityList
        {
            public T[] list;
        }

        protected string baseUrl;
        private string authToken;
        private string entityName;

        public HttpDao(string baseUrl, string authToken = null)
        {
            this.baseUrl = baseUrl;
            this.authToken = authToken;
            entityName = typeof(T).Name;
        }

        protected string appendParameters(string url, Hashtable parameters)
        {
            if (parameters == null || parameters.Count == 0)
            {
                return url;
            }

            List<string> combinations = new List<string>();
            foreach (string key in parameters.Keys)
            {
                combinations.Add(key + "=" + HttpUtility.UrlEncode((string)parameters[key]));
            }
 
            return url + '?' + string.Join("&", combinations);
        }

        protected UnityWebRequest setRequestHeaders(UnityWebRequest request, bool acceptText = false)
        {
            request.SetRequestHeader("UserAgent", "Unity3D/C#/Tradelite/SDK");
            request.SetRequestHeader("Accept", acceptText ? "text/plain" : "application/json; charset=UTF-8");
            request.SetRequestHeader("Content-Type", "application/json; charset=UTF-8"); // Harmless if not required
            if (authToken != null)
            {
                request.SetRequestHeader("Authorization", "Bearer " + authToken);
            }
            return request;
        }

        public async Task<T> Get(string id, Hashtable parameters = null)
        {
            string url = appendParameters(baseUrl + '/' + id + ".json", parameters);

            try
            {
                using var request = setRequestHeaders(UnityWebRequest.Get(url));

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
                    var jsonPayload = request.downloadHandler.text;

                    return JsonUtility.FromJson<T>(jsonPayload);
                }

            }
            catch (Exception ex)
            {
                Debug.LogError($"{nameof(Get)} for {entityName} w/ id: {id} failed with message: {ex.Message}");
            }

            return default;
        }

        public async Task<T[]> Select(Hashtable parameters = null)
        {
            string url = appendParameters(baseUrl + ".json", parameters);

            try
            {
                using var request = setRequestHeaders(UnityWebRequest.Get(url));

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
                    var jsonPayload = request.downloadHandler.text;

                    return JsonUtility.FromJson<EntityList>("{\"list\":" + jsonPayload + "}").list;
                }
                else if (request.responseCode == 203) // No Content
                {
                    return new T[0];
                }

            }
            catch (Exception ex)
            {
                Debug.LogError($"{nameof(Select)} of {entityName} entities failed with message: {ex.Message}");
            }

            return default;
        }

        public async Task<string> Create(T entity)
        {
            string url = baseUrl + ".txt";

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
                else if (request.responseCode == 201) // OK
                {
                    string location = request.GetResponseHeader("Location");

                    return location;
                }

            }
            catch (Exception ex)
            {
                Debug.LogError($"{nameof(Select)} of {entityName} entities failed with message: {ex.Message}");
            }

            return default;
        }
    }

}