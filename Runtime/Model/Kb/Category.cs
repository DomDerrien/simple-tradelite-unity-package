using System;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.KbScope
{
    [Serializable]
    public class Category : BaseModel
    {
        public string title = null;
        public string imageId = null;
        public string imageUrl = null;

        public override string ToString()
        {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);

            if (!string.IsNullOrEmpty(title)) output.Add($"title: `{title}`");
            if (!string.IsNullOrEmpty(imageId)) output.Add($"imageId: `{imageId}`");
            if (!string.IsNullOrEmpty(imageUrl)) output.Add($"imageUrl: `{imageUrl}`");

            return String.Join(", ", output);
        }
    }
}
