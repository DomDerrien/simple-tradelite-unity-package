using System;
using System.Collections;
using System.Threading.Tasks;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.DAO
{
    public interface AbstractDao<T> where T : BaseModel
    {
        // Asynchornous w/ async/await
        Task<T> Get(string id);
        Task<T[]> Select(Hashtable parameters);
        // Task<string> Create(T entity);
        // Task<string> Update(string id, T partialEntity);
        // Task Delete(string id);

        // // Asynchronous w/ callbacks
        // void Get(string id, Action<T> success, Action<BaseError> failure);
        // void Select(Hashtable parameters, Action<T[]> success, Action<BaseError> failure);
        // void Create(T entity, Action<string> success, Action<BaseError> failure);
        // void Update(String id, T partialEntity, Action<string> success, Action<BaseError> failure);
        // void Delete(string id, Action success, Action<BaseError> failure);
    }
}