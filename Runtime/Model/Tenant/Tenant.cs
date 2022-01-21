using System;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.TenantScope {
    [Serializable]
    public class Tenant : BaseModel {
        public long idExternal;
        public string name;
        public string industry;
        public string workRole;
        public string country;
        public string planName;

        public override string ToString() {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);
            if (idExternal != 0) output.Add($"idExternal: {idExternal}");
            if (!string.IsNullOrEmpty(name)) output.Add($"name: `{name}`");
            if (!string.IsNullOrEmpty(industry)) output.Add($"industry: `{industry}`");
            if (!string.IsNullOrEmpty(workRole)) output.Add($"workRole: `{workRole}`");
            if (!string.IsNullOrEmpty(country)) output.Add($"country: `{country}`");
            if (!string.IsNullOrEmpty(planName)) output.Add($"planName: `{planName}`");
            return String.Join(", ", output);
        }
    }
}
