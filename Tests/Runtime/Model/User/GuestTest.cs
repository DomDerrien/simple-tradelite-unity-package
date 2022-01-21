using NUnit.Framework;

namespace Tradelite.SDK.Model.UserScope {

    public class GuestTest {
        [Test]
        public void TestFreshGuestToString() {
            string id = "attr0";
            Guest entity =  new Guest{ 
                id = id
            };
            Assert.AreEqual(id, entity.id);
            Assert.AreEqual("id: `attr0`", entity.ToString());
        }

        [Test]
        public void TestCompleteGuestToString() {
            string id = "attr0";
            string nickname = "attr1";
            string locale = "attr2";
            string hash = "attr3";
            string userId = "attr4";
            Guest entity =  new Guest { 
                id = id,
                nickname = nickname,
                locale = locale,
                hash = hash,
                userId = userId
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "nickname: `attr1`, " + 
                "locale: `attr2`, " + 
                "hash: `**********`, " + 
                "userId: `attr4`", 
                entity.ToString()
            );
        }
   }
}