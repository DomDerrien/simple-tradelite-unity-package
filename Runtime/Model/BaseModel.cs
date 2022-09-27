using System;
using System.Collections.Generic;

namespace Tradelite.SDK.Model
{
    [Serializable]
    public class BaseModel
    {
        public string id;
        public long version = 1;
        public long created;
        public long updated;
        public string authorId;

        public override string ToString()
        {
            List<string> output = new List<string>();
            if (!string.IsNullOrEmpty(id)) output.Add($"id: `{id}`");
            if (version != 1) output.Add($"version: {version}");
            if (created != 0) output.Add($"created: {created}");
            if (updated != 0) output.Add($"updated: {updated}");
            if (!string.IsNullOrEmpty(authorId)) output.Add($"authorId: `{authorId}`");
            return String.Join(", ", output);
        }
    }
}