using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tradelite.SDK.Model;
using UnityEngine;
using UnityEngine.Networking;

namespace Tradelite.SDK.DAO
{
    public class LocalStorageDao<T> : AbstractDao<T> where T : BaseModel
    {

        private string entityName;
        private string gameId;
        private bool usePlayerPrefs;

        public LocalStorageDao(string gameId, bool usePlayerPrefs = true)
        {
            this.usePlayerPrefs = usePlayerPrefs;
            entityName = typeof(T).Name;
        }

        public void SetBasicAuthCredentials(string username, string password)
        {
            throw new NotSupportedException();
        }

        public Task<T> Get(string id, Hashtable parameters = null)
        {
            try
            {
                string key = $"_{gameId}_{entityName}_{id}";
                if (!PlayerPrefs.HasKey(key))
                {
                    return null;
                }

                string json = PlayerPrefs.GetString(key);
                return Task.FromResult(JsonUtility.FromJson<T>(json));
            }
            catch (Exception ex)
            {
                Debug.LogError($"{nameof(Get)} for {entityName} w/ id: {id} failed with message: {ex.Message}");
            }

            return default;
        }

        public Task<T[]> Select(Hashtable parameters = null)
        {
            throw new NotSupportedException();
        }

        public Task<string> Create(T entity)
        {
            return Create(entity, null);
        }

        public Task<string> Create(T entity, string idOverride)
        {
            try
            {
                string key = $"_{gameId}_{entityName}_{(idOverride == null ? entity.id : idOverride)}";
                PlayerPrefs.SetString(key, JsonUtility.ToJson(entity));
                return Task.FromResult(entity.id);
            }
            catch (Exception ex)
            {
                Debug.LogError($"{nameof(Create)} of {entityName} w/ id: {entity.id} failed with message:: {ex.Message}");
            }

            return default;
        }

        public Task<string> Update(string id, T partialEntity)
        {
            throw new NotSupportedException();
        }

        public Task Delete(string id)
        {
            try
            {
                string key = $"_{gameId}_{entityName}_{id}";
                PlayerPrefs.DeleteKey(key);

            }
            catch (Exception ex)
            {
                Debug.LogError($"{nameof(Delete)} of {entityName} w/ id: {id} failed with message:: {ex.Message}");
            }

            return default;
        }
    }
}
