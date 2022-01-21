using NUnit.Framework;
using Tradelite.SDK.Model.TenantScope;

namespace Tradelite.SDK.Model.UserScope {

    public class UserTest {
        [Test]
        public void TestFreshUserToString() {
            string id = "attr0";
            User entity =  new User{ 
                id = id
            };
            Assert.AreEqual(id, entity.id);
            Assert.AreEqual("id: `attr0`, ageVerification: False, mobile: True", entity.ToString());
        }

        [Test]
        public void TestCompleteUserToString() {
            string id = "attr0";
            long idExternal = 1;
            string status = "attr2";
            string email = "attr3";
            string firstname = "attr4";
            string middlename = "attr5";
            string lastname = "attr6";
            string maidenname = "attr7";
            string nickname = "attr8";
            string password = "attr9";
            string birthday = "attr10";
            string locale = "attr11";
            string dateAcceptConditions = "attr12";
            string acceptConditionsVersion = "attr13";
            bool ageVerification = true;
            bool mobile = true;
            string tenantId = "attr14";
            Tenant tenant = new Tenant {
                id = id
            };
            User entity =  new User { 
                id = id,
                idExternal = idExternal,
                status = status,
                email = email,
                firstname = firstname,
                middlename = middlename,
                lastname = lastname,
                maidenname = maidenname,
                nickname = nickname,
                password = password,
                birthday = birthday,
                locale = locale,
                dateAcceptConditions = dateAcceptConditions,
                acceptConditionsVersion = acceptConditionsVersion,
                ageVerification = ageVerification,
                mobile = mobile,
                tenantId = tenantId,
                tenant = tenant
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "idExternal: 1, " + 
                "status: `attr2`, " + 
                "email: `attr3`, " + 
                "firstname: `attr4`, " + 
                "middlename: `attr5`, " + 
                "lastname: `attr6`, " + 
                "maidenname: `attr7`, " + 
                "nickname: `attr8`, " + 
                "password: `**********`, " + 
                "birthday: `attr10`, " + 
                "locale: `attr11`, " + 
                "dateAcceptConditions: `attr12`, " + 
                "acceptConditionsVersion: `attr13`, " + 
                "ageVerification: True, " + 
                "mobile: True, " + 
                "tenantId: `attr14`, " + 
                "tenant: { id: `attr0` }", 
                entity.ToString()
            );
        }
   }
}