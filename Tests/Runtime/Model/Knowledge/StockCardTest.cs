using System;
using NUnit.Framework;

namespace Tradelite.SDK.Model.KnowledgeScope {

    public class RoleTest {
        [Test]
        public void TestFreshRoleToString() {
            string id = "attr0";
            Role entity =  new Role{ 
                id = id
            };
            Assert.AreEqual(id, entity.id);
            Assert.AreEqual("id: `attr0`, type: `CEO`, fullname: `unknown`", entity.ToString());
        }

        [Test]
        public void TestCompleteRoleToString() {
            string id = "attr0";
            RoleType type = RoleType.BoardDirector;
            string fullname = "attr2";
            string nationality = "attr3";
            Address address = new Address {
                country = "attr4"
            };
            Role entity =  new Role { 
                id = id,
                type = type,
                fullname = fullname,
                nationality = nationality,
                address = address,
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "type: `BoardDirector`, " + 
                "fullname: `attr2`, " + 
                "nationality: `attr3`, " + 
                "address: { country: `attr4` }", 
                entity.ToString()
            );
        }
   }

    public class QuoteTest {
        [Test]
        public void TestFreshQuoteToString() {
            string id = "attr0";
            Quote entity =  new Quote{ 
                id = id
            };
            Assert.AreEqual(id, entity.id);
            Assert.AreEqual("id: `attr0`, date: ``, value: 0", entity.ToString());
        }

        [Test]
        public void TestCompleteQuoteToString() {
            string id = "attr0";
            string date = "attr1";
            double value = 888.88;
            Quote entity =  new Quote { 
                id = id,
                date = date,
                value = value,
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "date: `attr1`, " + 
                "value: 888.88", 
                entity.ToString()
            );
        }
   }
}