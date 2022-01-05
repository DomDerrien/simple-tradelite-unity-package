using NUnit.Framework;
using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.Test {

    public class BaseModelTest {
        [Test]
        public void TestToString() {
            BaseModel entity =  new BaseModel();
            string toString = entity.ToString();
            Assert.IsEqual("id: ``", toString);
        }
    }
}