using System;
using System.Collections;
using System.Collections.Generic;
using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.MatchingScope {
    [Serializable]
    public class Question : BaseModel {
        public Category category = Category.ceoName;
        public string[] locales = new string[] { "en" };
        public int choiceNb = 2;
        public bool useShort = false;
        public string shortQuestionId;
        public string longQuestionId;
        public string[] shortChoiceIds;
        public string[] longChoiceIds;

        public override string ToString() {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);
            output.Add($"category: `{category}`");
            output.Add($"locales: ({locales.Length}) {(locales.Length == 0 ? "[]" : $"[ `{String.Join<string>("`, `", locales)}` ]")}");
            output.Add($"choiceNb: {choiceNb}");
            output.Add($"useShort: {useShort}");
            if (0 < choiceNb) {
                if (useShort) {
                    output.Add($"shortQuestionId: `{shortQuestionId}`");
                    output.Add($"shortChoiceIds: ({shortChoiceIds.Length}) [ `{String.Join<string>("`, `", shortChoiceIds)}` ]");
                }
                else {
                    output.Add($"longQuestionId: `{longQuestionId}`");
                    output.Add($"longChoiceIds: ({longChoiceIds.Length}) [ `{String.Join<string>("`, `", longChoiceIds)}` ]");
                }
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