using System;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.MatchingScope {
    [Serializable]
    public class Answer : BaseModel {
        public int validIdx = -1;
        public int scoreWeight = 0;

        public override string ToString() {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);
            output.Add($"validIdx: {validIdx}");
            output.Add($"scoreWeight: {scoreWeight}");
            return String.Join(", ", output);
        }
    }
}
