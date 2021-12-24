using System;
using System.Collections;
using System.Collections.Generic;
using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.MatchingScope {
    [Serializable]
    public class Question : BaseModel {
        public Category category;
        public string[] locales = new string[] { "en" };
        public int choiceNb = 2;
        public bool useShort = true;
        public string shortQuestionId;
        public string longQuestionId;
        public string[] shortChoiceIds;
        public string[] longChoiceIds;

        public override string ToString() {
            List<string> output = new List<string>();
            output.Add(base.ToString());
            output.Add($"category: {category}");
            output.Add($"locales: ({locales.Length}) [ `{String.Join<string>("`, `", locales)}` ]");
            output.Add($"choiceNb: {choiceNb}");
            if (useShort) {
                output.Add($"shortQuestionId: `{shortQuestionId}`");
                output.Add($"shortChoiceIds: ({shortChoiceIds.Length}) [ `{String.Join<string>("`, `", shortChoiceIds)}` ]");
            }
            else {
                output.Add($"longQuestionId: `{longQuestionId}`");
                output.Add($"longChoiceIds: (`{longChoiceIds.Length}) [ {String.Join<string>("`, `", longChoiceIds)}` ]");
            }
            return String.Join(", ", output);
        }
    }

    public enum Category {
        quaterlyPerformance,
        yearlyPerformance,
        ceoName,
        hqCountry,
        boardDirectorName,
        headQuarterLocation,
        lastYearMarketCapitalization,
        lastMonthMarketCapitalization,

    }
}