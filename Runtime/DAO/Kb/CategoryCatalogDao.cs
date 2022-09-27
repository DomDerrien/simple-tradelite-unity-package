using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tradelite.SDK.DAO;
using Tradelite.SDK.Model.KbScope;
using UnityEngine;
using UnityEngine.Networking;

namespace Tradelite.SDK.DAO.KbScope
{

    public class CategoryCatalogDao : HttpDao<CategoryCatalog>
    {
        public CategoryCatalogDao() : base(DataSource.KbCategory)
        { }

        public async Task<CategoryCatalog> Get()
        {
            return await Get("_folderCatalog");
        }
    }
}