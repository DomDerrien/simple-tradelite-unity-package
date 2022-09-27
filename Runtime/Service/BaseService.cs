using System;
using System.Collections;
using System.Threading.Tasks;

using Tradelite.SDK.DAO;
using Tradelite.SDK.Model;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service
{
    public class BaseService<T> where T : BaseModel
    {
        protected AbstractDao<T> dao;
        protected string entityName;

        protected BaseService()
        {
            entityName = typeof(T).Name;
        }

        public virtual async Task<T> Get(string id, Hashtable parameters = null)
        {
            return await dao.Get(id, parameters);
        }

        public async void Get(string id, Hashtable parameters, Action<T> success, Action<BaseError> failure)
        {
            try
            {
                success?.Invoke(await Get(id, parameters));
            }
            catch (Exception ex)
            {
                failure?.Invoke(new BaseError($"Cannot get entity of class {entityName} with id: {id}", ex));
            }
        }

        public virtual async Task<T[]> Select(Hashtable parameters = null)
        {
            return await dao.Select(parameters);
        }

        public async void Select(Hashtable parameters, Action<T[]> success, Action<BaseError> failure)
        {
            try
            {
                success?.Invoke(await Select(parameters));
            }
            catch (Exception ex)
            {
                failure?.Invoke(new BaseError($"Cannot select entities of class {entityName}", ex));
            }
        }

        public virtual async Task<string> Create(T entity)
        {
            return await dao.Create(entity);
        }

        public async void Create(T entity, Action<string> success, Action<BaseError> failure)
        {
            try
            {
                success?.Invoke(await Create(entity));
            }
            catch (Exception ex)
            {
                failure?.Invoke(new BaseError($"Cannot create entity of class {entityName}", ex));
            }
        }
 
        public async virtual Task Delete(string id)
        {
            await dao.Delete(id);
        }

        public async void Delete(string id, Action success, Action<BaseError> failure)
        {
            try
            {
                await Delete(id);
                success?.Invoke();
            }
            catch (Exception ex)
            {
                failure?.Invoke(new BaseError($"Cannot delete entity of class {entityName} w/ id {id}", ex));
            }
        }    }
}