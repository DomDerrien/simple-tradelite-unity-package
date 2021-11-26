using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

using UnityEngine;
using UnityEngine.Networking;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.DAO
{
    public class HttpDao<T> : AbstractDao<T> where T : BaseModel
    {
        [Serializable]
        private class EntityList {
            public T[] list;
        }

        private string baseUrl;
		private string entityName;

        public HttpDao(string baseUrl)
        {
            this.baseUrl = baseUrl;
			entityName = typeof(T).Name;
        }

        public async Task<T> Get(string id)
        {
            string url = baseUrl + '/' + id + ".json";

            try
            {
                using var request = UnityWebRequest.Get(url);

                request.SetRequestHeader("UserAgent", "Unity3D/C#/Tradelite/SDK");
                request.SetRequestHeader("Accept", "application/json; charset=UTF-8");

                var operation = request.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Failed: {request.error}");
                }

                if (request.responseCode == 200) // OK
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
            string url = baseUrl + ".json";

            if (parameters != null)
            {
                List<string> combinations = new List<string>();
                foreach(string key in parameters.Keys) {
                    combinations.Add(key + "=" + HttpUtility.UrlEncode((string) parameters[key]));
                }
                if (0 < combinations.Count)
                {
                    url += '?' + string.Join("&", combinations);
                }
            }

            try
            {
                using var request = UnityWebRequest.Get(url);

                request.SetRequestHeader("UserAgent", "Unity3D/C#/Tradelite/SDK");
                request.SetRequestHeader("Accept", "application/json; charset=UTF-8");

                var operation = request.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Failed: {request.error}");
                }

                if (request.responseCode == 200) // OK
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
    }

}