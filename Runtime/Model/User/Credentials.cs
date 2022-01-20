using System;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.UserScope {
    [Serializable]
    public class Credentials : BaseModel {
        public string username;
        public string password;
        public string grant_type = "password";

        public AuthorizationResponse fullToken = null;

        public override string ToString() {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);
            if (!string.IsNullOrEmpty(username)) output.Add($"username: `{username}`");
            if (!string.IsNullOrEmpty(password)) output.Add($"password: `**********`");
            if (!string.IsNullOrEmpty(grant_type)) output.Add($"grant_type: `{grant_type}`");
            if (fullToken != null) output.Add($"fullToken: {{ {fullToken.ToString()} }}");
            return String.Join(", ", output);
        }
    }

    [Serializable]
    public class AuthorizationResponse : BaseModel {
        public string access_token = "";
        public string token_type = "";
        public string refresh_token = "";
        public string expires_in = "";
        public string scope = "";
        public long userid = -1;
        public new long id = -1; // Override of the BaseModel `id`

        public override string ToString() {
            List<string> output = new List<string>();
            output.Add($"id: {id}");
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);
            if (!string.IsNullOrEmpty(access_token)) output.Add($"access_token: `{access_token}`");
            if (!string.IsNullOrEmpty(token_type)) output.Add($"token_type: `{token_type}`");
            if (!string.IsNullOrEmpty(refresh_token)) output.Add($"refresh_token: `{refresh_token}`");
            if (!string.IsNullOrEmpty(expires_in)) output.Add($"expires_in: `{expires_in}`");
            if (!string.IsNullOrEmpty(scope)) output.Add($"scope: `{scope}`");
            if (userid != -1) output.Add($"userid: {userid}");
            return String.Join(", ", output);
        }
    }
}