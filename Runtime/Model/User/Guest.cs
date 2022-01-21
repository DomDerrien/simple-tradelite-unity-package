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
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);

            if (!string.IsNullOrEmpty(nickname)) output.Add($"nickname: `{nickname}`");
            if (!string.IsNullOrEmpty(locale)) output.Add($"locale: `{locale}`");
            if (!string.IsNullOrEmpty(hash)) output.Add($"hash: `**********`");
            if (!string.IsNullOrEmpty(userId)) output.Add($"userId: `{userId}`");

            return String.Join(", ", output);
        }
    }
}