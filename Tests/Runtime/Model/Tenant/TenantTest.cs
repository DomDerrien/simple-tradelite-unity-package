using NUnit.Framework;

namespace Tradelite.SDK.Model.TenantScope {

    public class TenantTest {
        [Test]
        public void TestFreshTenantToString() {
            string id = "attr0";
            Tenant entity =  new Tenant{ 
                id = id
            };
            Assert.AreEqual(id, entity.id);
            Assert.AreEqual("id: `attr0`", entity.ToString());
        }

        [Test]
        public void TestCompleteTenantToString() {
            string id = "attr0";
            long idExternal = 1;
            string name = "attr2";
            string industry = "attr3";
            string workRole = "attr4";
            string country = "attr5";
            string planName = "attr6";
            Tenant entity =  new Tenant { 
                id = id,
                idExternal = idExternal,
                name = name,
                industry = industry,
                workRole = workRole,
                country = country,
                planName = planName
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "idExternal: 1, " + 
                "name: `attr2`, " + 
                "industry: `attr3`, " + 
                "workRole: `attr4`, " + 
                "country: `attr5`, " + 
                "planName: `attr6`", 
                entity.ToString()
            );
        }
   }
}