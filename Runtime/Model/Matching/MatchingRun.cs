using System;
using System.Collections;
using System.Collections.Generic;
using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.MatchingScope {
    [Serializable]
    public class MatchingRun : BaseModel {
        public string description;
        public int questionNb = -1;
        public string[] questionIds;
        public int lifeNb = 3;

        public override string ToString() {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);
            if (!string.IsNullOrEmpty(description)) output.Add($"description: `{description}`");
            output.Add($"questionNb: {(questionNb == -1 ? "`infinite`" : "" + questionNb)}");
            int questionIdNb = questionIds == null ? 0 : questionIds.Length;
            output.Add($"questionIds: ({questionIdNb}) {(questionIdNb == 0 ? "[]" : $"[ `{String.Join<string>("`, `", questionIds)}` ]")}");
            output.Add($"lifeNb: {lifeNb}");
            return String.Join(", ", output);
        }
    }
}