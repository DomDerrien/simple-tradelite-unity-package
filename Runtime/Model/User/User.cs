using System;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.UserScope {
    [Serializable]
    public class User : BaseModel {
        public string email = null;
        public string nickname = null;

        public override string ToString() {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);

            if (!string.IsNullOrEmpty(email)) output.Add($"email: `{email}`");
            if (!string.IsNullOrEmpty(nickname)) output.Add($"nickname: `{nickname}`");

            return String.Join(", ", output);
        }
    }
}
