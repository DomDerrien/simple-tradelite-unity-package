using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.ConfigScope {
    [Serializable]
    public class GameConfiguration : BaseModel {
        public ServiceEndpoint[] serviceEndpoints;
        public CredentialSet[] credentials;

        public string GetEndpoint(string key) {
            try {
                return serviceEndpoints.First(endpoint => endpoint.key == key).url;
            }
            catch (Exception) {
                throw new Exception($"Cannot get entry w/ key {key} from the loaded configuration!");
            }
        }

        public string GetCredential(string label) {
            try {
                return credentials.First(credential => credential.label == label).value;
            }
            catch (Exception) {
                throw new Exception($"Cannot get entry w/ key {label} from the loaded configuration!");
            }
        }

        public override string ToString() {
            List<string> output = new List<string>();
            output.Add(base.ToString());
            int endpointNb = serviceEndpoints == null ? 0 : serviceEndpoints.Length;
            output.Add($"questionIds: ({endpointNb}) [{(endpointNb == 0 ? "" : String.Join<ServiceEndpoint>(", ", serviceEndpoints))}]");
            return String.Join(", ", output);
        }
    }

    [Serializable]
    public class ServiceEndpoint {
        public string key;
        public string url;

        public override string ToString() {
            return "{ " + key + ": \"" + url + "\"}";
        }
    }

    [Serializable]
    public class CredentialSet {
        public string label;
        public string value;

        public override string ToString() {
            return "{ " + label + ": \"" + value + "\"}";
        }
    }
}