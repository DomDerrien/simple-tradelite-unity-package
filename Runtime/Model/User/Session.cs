using System;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.UserScope
{
    [Serializable]
    public class Session : BaseModel
    {
        public string locale = "en";

        public void SetLocale(string locale = "en")
        {
            this.locale = locale;
        }

        public override string ToString()
        {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);

            if (!string.IsNullOrEmpty(locale)) output.Add($"locale: `{locale}`");

            return String.Join(", ", output);
        }
    }
}
