using System;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.UserScope
{
    [Serializable]
    public class Credentials: BaseModel
    {
        public string username;
        public string password;
    }
}