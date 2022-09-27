using System;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.KbScope
{
    [Serializable]
    public class CategoryCatalog : BaseModel
    {
        public string title = null;
        public string[] categoryIds;

        public override string ToString()
        {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);

            if (!string.IsNullOrEmpty(title)) output.Add($"title: `{title}`");
            if (0 < categoryIds.Length) output.Add($"categoryIds: `{categoryIds}`");

            return String.Join(", ", output);
        }
    }
}
