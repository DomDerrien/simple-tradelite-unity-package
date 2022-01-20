using System;
using NUnit.Framework;

namespace Tradelite.SDK.Model {

    public class BaseErrorTest {
        [Test]
        public void TestFreshBaseErrorToString() {
            string message = "attr1";
            BaseError entity =  new BaseError(message);
            Assert.AreEqual(message, entity.message);
            Assert.AreEqual("message: `attr1`", entity.ToString());
        }

        [Test]
        public void TestCompleteBaseErrorToString() {
            string message = "attr1";
            Exception cause = new NotImplementedException("attr2");
            BaseError entity =  new BaseError(message, cause);
            Assert.AreEqual(message, entity.message);
            Assert.AreEqual(cause, entity.cause);
            Assert.AreEqual(
                "message: `attr1`, " + 
                "cause: `System.NotImplementedException: attr2`", 
                entity.ToString()
            );
        }
    }
}