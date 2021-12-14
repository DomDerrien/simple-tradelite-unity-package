using System;
using System.Collections.Generic;

using Tradelite.SDK.Model;
using Tradelite.SDK.Model.TenantScope;

namespace Tradelite.SDK.Model.UserScope
{
    [Serializable]
    public class User: BaseModel
    {
        public int idExternal;
        public string status = null;
        public string email = null;
        public string firstname = null;
        public string middlename = null;
        public string lastname = null;
        public string maidenname = null;
        public string nickname = null;
        public string password = null;
        public string birthday = null;

        public string dateAcceptConditions = null;
        public string acceptConditionsVersion = null;
        public bool ageVerification;
        public bool mobile = true;

        public string tenantId;
        public Tenant tenant = null;

        public override string ToString()
        {
            List<string> output = new List<string>();
            output.Add(base.ToString());
            
            if (idExternal != 0) output.Add( $"idExternal: {idExternal}");
            if (!string.IsNullOrEmpty(status)) output.Add( $"status: `{status}`");
            if (!string.IsNullOrEmpty(email)) output.Add( $"email: `{email}`");
            if (!string.IsNullOrEmpty(firstname)) output.Add( $"firstname: `{firstname}`");
            if (!string.IsNullOrEmpty(middlename)) output.Add( $"middlename: `{middlename}`");
            if (!string.IsNullOrEmpty(lastname)) output.Add( $"lastname: `{lastname}`");
            if (!string.IsNullOrEmpty(maidenname)) output.Add( $"maidenname: `{maidenname}`");
            if (!string.IsNullOrEmpty(nickname)) output.Add( $"nickname: `{nickname}`");
            if (!string.IsNullOrEmpty(password)) output.Add( $"password: `*********`");
            if (!string.IsNullOrEmpty(birthday)) output.Add( $"birthday: `{birthday}`");

            if (!string.IsNullOrEmpty(dateAcceptConditions)) output.Add( $"dateAcceptConditions: `{dateAcceptConditions}`");
            if (!string.IsNullOrEmpty(acceptConditionsVersion)) output.Add( $"acceptConditionsVersion: `{acceptConditionsVersion}`");
            output.Add( $"ageVerification: {(ageVerification ? "true" : "false")}");
            output.Add( $"mobile: {(mobile ? "true" : "false")}");
            
            if (!string.IsNullOrEmpty(tenantId)) output.Add( $"tenantId: `{tenantId}`");
            if (tenant != null) output.Add( $"tenant: {{ {tenant.ToString()} }}");

            return String.Join(", ", output);
        }
    }
}
