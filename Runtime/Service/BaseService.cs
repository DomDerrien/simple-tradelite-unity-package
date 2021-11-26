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
        private AbstractDao<T> dao;

        protected BaseService(string baseUrl)
        {
            dao = new HttpDao<T>(baseUrl);
        }

        public async Task<T> Get(string id) {
            return await dao.Get(id);
        }

        public async Task<T[]> Select(Hashtable parameters = null) {
            return await dao.Select(parameters);
        }
    }
}