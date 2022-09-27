using System;
using System.Collections;
using System.Threading.Tasks;

using Tradelite.SDK.DAO.KbScope;
using Tradelite.SDK.Model.KbScope;
using Tradelite.SDK.Service;

namespace Tradelite.SDK.Service.KbScope
{
    public class CategoryService : BaseService<Category>
    {
        private static CategoryService INSTANCE = null;

        public static CategoryService GetInstance(Boolean forceReload = false)
        {
            if (INSTANCE == null || forceReload)
            {
                INSTANCE = new CategoryService();
            }
            return INSTANCE;
        }

        private CategoryCatalogDao catalogDao;

        private CategoryService() : base()
        {
            dao = new CategoryDao();
            catalogDao = new CategoryCatalogDao();
        }

        public async Task<string[]> GetIds()
        {
            return (await catalogDao.Get()).categoryIds;
        }

        public async Task<Category[]> GetByIds(string[] ids)
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("id", ids);
            return await dao.Select(parameters);
        }
    }
}