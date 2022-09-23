using NUnit.Framework;

namespace Tradelite.SDK.Model {

    public class BaseModelTest {
        [Test]
        public void TestFreshBaseModelToString() {
            BaseModel entity =  new BaseModel();
            Assert.AreEqual("", entity.ToString());
        }

        [Test]
        public void TestCompleteBaseModelToString() {
            BaseModel entity =  new BaseModel {
                id = "attr0",
                version = 1,
                created = 2,
                updated = 3,
                authorId = "attr4",
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "created: 2, " + 
                "updated: 3, " + 
                "authorId: `attr4`", 
                entity.ToString()
            );
        }
    }
}