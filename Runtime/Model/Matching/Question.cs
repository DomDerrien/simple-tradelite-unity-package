using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.MatchingScope
{
    [Serializable]
    public class Question: BaseModel
    {
        public Category category;
        public string[] locales = new string[] { "en" };
        public bool useShort = true;
        public string shortQuestionId;
        public string longQuestionId;
        public string[] shortChoiceIds;
        public string[] longChoiceIds;

        public override string ToString()
        {
            List<string> output = new List<string>();
            output.Add(base.ToString());
            output.Add($"category: {category}");
            output.Add($"locales: ({locales.Count()}) [ {String.Join<string>(", ", locales)} ]");
            if (useShort)
            {
                output.Add($"shortQuestionId: {shortQuestionId}");
                output.Add($"shortChoiceIds: ({shortChoiceIds.Count()}) [ {String.Join<string>(", ", shortChoiceIds)} ]");
            }
            else
            {
                output.Add($"longQuestionId: {longQuestionId}");
                output.Add($"longChoiceIds: ({longChoiceIds.Count()}) [ {String.Join<string>(", ", longChoiceIds)} ]");
            }
            return String.Join(", ", output);
        }
    }

    public enum Category
    {
        quaterlyPerformance,
        yearlyPerformance,
        ceoName,
        boardDirectorName,
        headQuarterLocation,
        lastYearMarketCapitalization,
        lastMonthMarketCapitalization,
        
    }
}