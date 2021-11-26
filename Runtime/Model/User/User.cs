using System;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.UserScope
{
    [Serializable]
    public class User: BaseModel {
        public string firstname;
        public string lastname;
        public string birthday;

        public override string ToString()
        {
            List<string> output = new List<string>();
            output.Add(base.ToString());
            if (!string.IsNullOrEmpty(firstname)) output.Add( $"firstname: `{firstname}`");
            if (!string.IsNullOrEmpty(lastname)) output.Add( $"lastname: `{lastname}`");
            if (!string.IsNullOrEmpty(birthday)) output.Add( $"birthday: `{birthday}`");
            return String.Join(", ", output);
        }
    }
}