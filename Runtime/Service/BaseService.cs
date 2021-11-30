using System;
using System.Collections;
using System.Threading.Tasks;

using Tradelite.SDK.DAO;
using Tradelite.SDK.Model;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service
{
    public class BaseService<T> where T: BaseModel
    {
        protected AbstractDao<T> dao;

        protected BaseService(string baseUrl, string token = null)
        {
            dao = new HttpDao<T>(baseUrl, token);
        }

        public async Task<T> Get(string id) {
            return await dao.Get(id);
        }

        public async Task<T[]> Select(Hashtable parameters = null) 
        {
            return await dao.Select(parameters);
        }

        public async Task<string> Create(T entity) 
        {
            return await dao.Create(entity);
        }
    }
}