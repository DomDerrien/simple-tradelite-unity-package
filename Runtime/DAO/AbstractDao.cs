using System;
using System.Collections;
using System.Threading.Tasks;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.DAO
{
    public interface AbstractDao<T> where T : BaseModel
    {
        Task<T> Get(string id, Hashtable parameters = null);
        Task<T[]> Select(Hashtable parameters = null);
        Task<string> Create(T entity);
        // Task<string> Update(string id, T partialEntity);
        // Task Delete(string id);

        // static void setBasicAuthCredentials(string username, string password) => throw new NotImplementedException();
        void SetBasicAuthCredentials(string username, string password);
    }
}