using System;
using System.Collections.Generic;

namespace Tradelite.SDK.Model {
    [Serializable]
    public class BaseModel {
        public string id;
        public string dateCreated = null;
        public string dateUpdate = null;
        public string dateSuspend = null;
        public string dateDeleted = null;
        public string ownerId;

        public override string ToString() {
            List<string> output = new List<string>();
            if (!string.IsNullOrEmpty(id)) output.Add($"id: `{id}`");
            if (!string.IsNullOrEmpty(dateCreated)) output.Add($"dateCreated: `{dateCreated}`");
            if (!string.IsNullOrEmpty(dateUpdate)) output.Add($"dateUpdate: `{dateUpdate}`");
            if (!string.IsNullOrEmpty(dateSuspend)) output.Add($"dateSuspend: `{dateSuspend}`");
            if (!string.IsNullOrEmpty(dateDeleted)) output.Add($"dateDeleted: `{dateDeleted}`");
            if (!string.IsNullOrEmpty(ownerId)) output.Add($"ownerId: `{ownerId}`");
            return String.Join(", ", output);
        }
    }
}