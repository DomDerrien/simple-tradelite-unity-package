using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tradelite.SDK.DAO;
using Tradelite.SDK.Model.UserScope;
using UnityEngine;
using UnityEngine.Networking;

namespace Tradelite.SDK.DAO.UserScope {

    public class UserDao : HttpDao<User> {
        public UserDao() : base(DataSource.User) { }

        public override Task<User> Get(string id, Hashtable parameters = null) {
            throw new InvalidOperationException("Unsupported operation");
        }
    }
}