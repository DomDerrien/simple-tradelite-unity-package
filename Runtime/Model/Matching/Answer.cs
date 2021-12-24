using System;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.MatchingScope {
    [Serializable]
    public class Answer : BaseModel {
        public int validIdx = 0;
        public int scoreWeight = 10;

        public override string ToString() {
            List<string> output = new List<string>();
            output.Add(base.ToString());
            output.Add($"validIdx: {validIdx}");
            output.Add($"scoreWeight: {scoreWeight}");
            return String.Join(", ", output);
        }
    }
}
