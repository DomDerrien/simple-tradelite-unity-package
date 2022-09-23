using NUnit.Framework;

namespace Tradelite.SDK.Model.UserScope {

    public class UserTest {
        [Test]
        public void TestFreshUserToString() {
            string id = "attr0";
            User entity =  new User{ 
                id = id
            };
            Assert.AreEqual(id, entity.id);
            Assert.AreEqual("id: `attr0`", entity.ToString());
        }

        [Test]
        public void TestCompleteUserToString() {
            string id = "attr0";
            long version = 10;
            long created = 2;
            long updated = 3;
            string email = "attr4";
            string nickname = "attr5";
            User entity =  new User { 
                id = id,
                version = version,
                created = created,
                updated = updated,
                email = email,
                nickname = nickname,
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "version: 10, " + 
                "created: 2, " + 
                "updated: 3, " + 
                "email: `attr4`, " + 
                "nickname: `attr5`", 
                entity.ToString()
            );
        }
   }
}