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
                dateCreated = "attr1",
                dateUpdate = "attr2",
                dateSuspend = "attr3",
                dateDeleted = "attr4",
                ownerId = "attr5",
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "dateCreated: `attr1`, " + 
                "dateUpdate: `attr2`, " + 
                "dateSuspend: `attr3`, " + 
                "dateDeleted: `attr4`, " + 
                "ownerId: `attr5`", 
                entity.ToString()
            );
        }
    }
}