using System;
using System.Collections.Generic;

namespace Tradelite.SDK.Model
{
    [Serializable]
    public class BaseModel
    {
        public string id;
        public long created;
        public long updated;
        public string ownerId;

        public override string ToString()
        {
            List<string> output = new List<string>();
            output.Add($"id: `{id}`");
            if (created != 0) output.Add( $"created: {created}");
            if (updated != 0) output.Add( $"updated: {updated}");
            if (!string.IsNullOrEmpty(ownerId)) output.Add( $"ownerId: `{ownerId}`");
            return String.Join(", ", output);
        }
    }
}