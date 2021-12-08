using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.MatchingScope
{
    [Serializable]
    public class MatchingRun: BaseModel
    {
        public int questionNb = -1;
        public string[] questionIds;
        public int liveNb = 3;

        public override string ToString()
        {
            List<string> output = new List<string>();
            output.Add(base.ToString());
            output.Add($"questionNb: {(questionNb == -1 ? "infinite" : "" + questionNb)}");
            int questionIdNb = questionIds.Count();
            output.Add($"questionIds: ({questionIdNb}) [{(questionIdNb == 0 ? "" : String.Join<string>(", ", questionIds))}]");
            output.Add($"liveNb: {liveNb}");
            return String.Join(", ", output);
        }
    }
}