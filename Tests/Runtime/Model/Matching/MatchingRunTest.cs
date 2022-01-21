using System;
using NUnit.Framework;

namespace Tradelite.SDK.Model.MatchingScope {

    public class MatchingRunTest {
        [Test]
        public void TestFreshMatchingRunToString() {
            string id = "attr0";
            MatchingRun entity =  new MatchingRun{ 
                id = id
            };
            Assert.AreEqual(id, entity.id);
            Assert.AreEqual("id: `attr0`, questionNb: `infinite`, questionIds: (0) [], lifeNb: 3", entity.ToString());
        }

        [Test]
        public void TestCompleteMatchingRunToString() {
            string id = "attr0";
            string description = "attr1";
            int questionNb = 888;
            string[] questionIds = new string[] { "id0", "id1", "id2", "id3"};
            int lifeNb = 0;
            MatchingRun entity =  new MatchingRun { 
                id = id,
                description = description,
                questionNb = questionNb,
                questionIds = questionIds,
                lifeNb = lifeNb,
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "description: `attr1`, " + 
                "questionNb: 888, " + 
                "questionIds: (4) [ `id0`, `id1`, `id2`, `id3` ], " + 
                "lifeNb: 0", 
                entity.ToString()
            );
        }
   }
}