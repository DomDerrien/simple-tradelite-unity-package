using System;
using NUnit.Framework;

namespace Tradelite.SDK.Model.MatchingScope {

    public class QuestionTest {
        [Test]
        public void TestFreshQuestionToString() {
            string id = "attr0";
            Question entity =  new Question{ 
                id = id,
                locales = new string[0],
                choiceNb = 0
            };
            Assert.AreEqual(id, entity.id);
            Assert.AreEqual("id: `attr0`, category: `ceoName`, locales: (0) [], choiceNb: 0, useShort: False", entity.ToString());
        }

        [Test]
        public void TestCompleteShortQuestionToString() {
            string id = "attr0";
            Category category = Category.yearlyPerformance;
            string[] locales = new string[] { "en", "zn-tw", "fr", "de"};
            int choiceNb = 888;
            bool useShort = true;
            string shortQuestionId = "attr5";
            string[] shortChoiceIds = new string[] { "short" };
            string longQuestionId = "attr6";
            string[] longChoiceIds = new string[] { "long" };
            Question entity =  new Question { 
                id = id,
                category = category,
                locales = locales,
                choiceNb = choiceNb,
                useShort = useShort,
                shortQuestionId = shortQuestionId,
                shortChoiceIds = shortChoiceIds,
                longQuestionId = longQuestionId,
                longChoiceIds = longChoiceIds
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "category: `yearlyPerformance`, " + 
                "locales: (4) [ `en`, `zn-tw`, `fr`, `de` ], " + 
                "choiceNb: 888, " + 
                "useShort: True, " + 
                "shortQuestionId: `attr5`, " + 
                "shortChoiceIds: (1) [ `short` ]", 
                entity.ToString()
            );
        }

        [Test]
        public void TestCompleteLongQuestionToString() {
            string id = "attr0";
            Category category = Category.yearlyPerformance;
            string[] locales = new string[] { "en", "zn-tw", "fr", "de"};
            int choiceNb = 888;
            bool useShort = false;
            string shortQuestionId = "attr5";
            string[] shortChoiceIds = new string[] { "short" };
            string longQuestionId = "attr6";
            string[] longChoiceIds = new string[] { "long" };
            Question entity =  new Question { 
                id = id,
                category = category,
                locales = locales,
                choiceNb = choiceNb,
                useShort = useShort,
                shortQuestionId = shortQuestionId,
                shortChoiceIds = shortChoiceIds,
                longQuestionId = longQuestionId,
                longChoiceIds = longChoiceIds
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "category: `yearlyPerformance`, " + 
                "locales: (4) [ `en`, `zn-tw`, `fr`, `de` ], " + 
                "choiceNb: 888, " + 
                "useShort: False, " + 
                "longQuestionId: `attr6`, " + 
                "longChoiceIds: (1) [ `long` ]", 
                entity.ToString()
            );
        }
   }
}