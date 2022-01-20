using NUnit.Framework;

namespace Tradelite.SDK.Model.UserScope {

    public class CredentialsTest {
        [Test]
        public void TestFreshCredentialsToString() {
            string id = "attr0";
            Credentials entity =  new Credentials{ 
                id = id
            };
            Assert.AreEqual(id, entity.id);
            Assert.AreEqual("id: `attr0`, grant_type: `password`", entity.ToString());
        }

        [Test]
        public void TestCompleteCredentialsToString() {
            string id = "attr0";
            string password = "attr1";
            string grant_type = "attr2";
            Credentials entity =  new Credentials { 
                id = id,
                password = password,
                grant_type = grant_type
            };
            Assert.AreEqual(
                "id: `attr0`, " + 
                "password: `**********`, " + 
                "grant_type: `attr2`", 
                entity.ToString()
            );
        }
    }

    public class AuthorizationResponseTest {
        [Test]
        public void TestFreshAuthorizationResponseToString() {
            long id = 0; // id is overriden from BaseModel
            AuthorizationResponse entity =  new AuthorizationResponse {
                id = id
            };
            Assert.AreEqual(id, entity.id);
            Assert.AreEqual("id: 0", entity.ToString());
        }

        [Test]
        public void TestCompleteAuthorizationResponseToString() {
            long id = 0;
            string access_token = "attr1";
            string token_type = "attr2";
            string refresh_token = "attr3";
            string expires_in = "attr4";
            string scope = "attr5";
            long userid = 6;
            AuthorizationResponse entity =  new AuthorizationResponse {
                id = id,
                access_token = access_token,
                token_type = token_type,
                refresh_token = refresh_token,
                expires_in = expires_in,
                scope = scope,
                userid = userid
            };
            Assert.AreEqual(
                "id: 0, " + 
                "access_token: `attr1`, " + 
                "token_type: `attr2`, " + 
                "refresh_token: `attr3`, " + 
                "expires_in: `attr4`, " + 
                "scope: `attr5`, " + 
                "userid: 6", 
                entity.ToString()
            );
        }
    }
}