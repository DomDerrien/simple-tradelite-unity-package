using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tradelite.SDK.Model;
using UnityEngine;
using UnityEngine.Networking;

namespace Tradelite.SDK.DAO {

    internal static class StaticAuthInfo {
        public static string jwtToken { get; set; }
    }

    public class HttpDao<T> : AbstractDao<T> where T : BaseModel {
        [Serializable]
        private class EntityList {
            public T[] list;
        }

        public static string jwtToken {
            get { return StaticAuthInfo.jwtToken; }
            set { StaticAuthInfo.jwtToken = value; }
        }

        protected Boolean fromS3;
        protected string baseUrl;
        private string entityName;
        private UTF8Encoding encoder = new UTF8Encoding();

        public HttpDao(string dataSource) {
            this.baseUrl = dataSource;
            this.fromS3 = dataSource.ToString().IndexOf("/data") != -1;
            entityName = typeof(T).Name;
        }

        public string composeUrl(string baseUrl) {
            return composeUrl(baseUrl, null);
        }

        protected string composeUrl(string baseUrl, string id) {
            string candidateUrl = baseUrl;
            if (id != null) {
                candidateUrl += "/" + id;
            }
            string extension = (fromS3 ? ".json" : "");
            return candidateUrl + extension;
        }

        protected string appendParameters(string url, Hashtable parameters) {
            if (parameters == null || parameters.Count == 0) {
                return url;
            }

            List<string> combinations = new List<string>();
            foreach (string key in parameters.Keys) {
                var value = parameters[key];
                if (value.GetType() == typeof(string[])) {
                    foreach (string individual in ((string[])value)) {
                        combinations.Add(key + "=" + HttpUtility.UrlEncode((string)individual));
                    }
                }
                else {
                    combinations.Add(key + "=" + HttpUtility.UrlEncode((string)value));
                }
            }

            return url + '?' + string.Join("&", combinations);
        }

        protected UnityWebRequest setRequestHeaders(UnityWebRequest request, bool acceptText = false) {
            request.SetRequestHeader("UserAgent", "Unity3D/C#/Tradelite/SDK");
            request.SetRequestHeader("Accept", acceptText ? "text/plain" : "application/json; charset=UTF-8");
            request.SetRequestHeader("Content-Type", "application/json; charset=UTF-8"); // Harmless if not required
            if (!fromS3 && jwtToken != null) {
                request.SetRequestHeader("Authorization", "Bearer " + jwtToken);
            }
            return request;
        }

        public virtual async Task<T> Get(string id, Hashtable parameters = null) {
            string url = appendParameters(composeUrl(baseUrl, id), parameters);

            try {
                using var request = setRequestHeaders(UnityWebRequest.Get(url));

                var operation = request.SendWebRequest();

                while (!operation.isDone) {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success) {
                    Debug.LogError($"HttpDao.Get() failed:\n- {request.error}\n- {request.downloadHandler.text}");
                }
                else if (request.responseCode == 200) // OK
                {
                    var jsonPayload = request.downloadHandler.text;

                    return JsonUtility.FromJson<T>(jsonPayload);
                }
            }
            catch (Exception ex) {
                Debug.LogError($"{nameof(Get)} for {entityName} w/ id: {id} failed with message: {ex.Message}");
            }

            return default;
        }

        public virtual async Task<T[]> Select(Hashtable parameters = null) {
            string url = appendParameters(composeUrl(baseUrl), parameters);

            try {
                using var request = setRequestHeaders(UnityWebRequest.Get(url));

                var operation = request.SendWebRequest();

                while (!operation.isDone) {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success) {
                    Debug.LogError($"HttpDao.Select() failed:\n- {request.error}\n- {request.downloadHandler.text}");
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
            catch (Exception ex) {
                Debug.LogError($"{nameof(Select)} of {entityName} entities failed with message: {ex.Message}");
            }

            return default;
        }

        public virtual async Task<string> Create(T entity) {
            string url = composeUrl(baseUrl);

            try {
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

                while (!operation.isDone) {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success) {
                    Debug.LogError($"HttpDao.Create() failed:\n- {request.error}\n- {request.downloadHandler.text}");
                }
                else if (request.responseCode == 201) // OK
                {
                    string location = request.GetResponseHeader("Location");

                    return location.Substring(location.LastIndexOf('/') + 1);
                }
            }
            catch (Exception ex) {
                Debug.LogError($"{nameof(Select)} of {entityName} entities failed with message: {ex.Message}");
            }

            return default;
        }

        public virtual Task<string> Update(string id, T partialEntity) {
            throw new NotSupportedException();
        }

        public virtual Task Delete(string id) {
            throw new NotSupportedException();
        }
    }

}