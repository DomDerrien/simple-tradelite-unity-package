using System;
using System.Collections;
using System.Collections.Generic;
using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.UserScope {
    [Serializable]
    public class Guest : BaseModel {

        public string nickname;
        public string locale;
        public string hash;
        public string userId;

        public override string ToString() {
            List<string> output = new List<string>();
            output.Add(base.ToString());

            output.Add($"nickname: `{nickname}`");
            output.Add($"locale: `{locale}`");
            output.Add($"hash: `*********`");
            output.Add($"userId: `{userId}`");

            return String.Join(", ", output);
        }
    }
}