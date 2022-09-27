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

    public class CategoryDao : HttpDao<Category>
    {
        public CategoryDao() : base(DataSource.KbCategory)
        { }

        public override async Task<Category[]> Select(Hashtable parameters = null)
        {
            var idParam = parameters["id"];
            if (idParam.GetType() == typeof(string[]))
            {
                string[] ids = (string[]) idParam;
                var getRequests = Array.ConvertAll(ids, id => Get(id));
                return await Task.WhenAll(getRequests);
            }
            
            throw new NotSupportedException();
        }
    }
}