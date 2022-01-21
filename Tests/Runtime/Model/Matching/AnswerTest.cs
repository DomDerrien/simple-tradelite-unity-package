using System;
using NUnit.Framework;

namespace Tradelite.SDK.Model.MatchingScope {

    public class AnswerTest {
        [Test]
        public void TestFreshAnswerToString() {
            string id = "attr0";
            Answer entity =  new Answer{ 
                id = id
            };
            Assert.AreEqual(id, entity.id);
            Assert.AreEqual("id: `attr0`, validIdx: -1, scoreWeight: 0", entity.ToString());
        }

        [Test]
        public void TestCompleteAnswerToString() {
            string id = "attr0";
            int validIdx = 888;
            int scoreWeight = 1000000;
            Answer entity =  new Answer { 
                id = id,
                validIdx = validIdx,
                scoreWeight = scoreWeight,
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "validIdx: 888, " + 
                "scoreWeight: 1000000", 
                entity.ToString()
            );
        }
   }
}