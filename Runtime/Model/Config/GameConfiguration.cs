using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.ConfigScope
{
    [Serializable]
    public class GameConfiguration: BaseModel
    {
        public ServiceEndpoint[] serviceEndpoints;

        public string GetEndpoint(string key) {
            return serviceEndpoints.First(endpoint => endpoint.key == key).url;
        }

        public override string ToString()
        {
            List<string> output = new List<string>();
            output.Add(base.ToString());
            int endpointNb = serviceEndpoints == null ? 0 : serviceEndpoints.Length;
            if (endpointNb == 0)
            {
                output.Add($"serviceEndpoints: (0) []");
            }
            else
            {
                output.Add($"serviceEndpoints: ({endpointNb}) [ {String.Join<ServiceEndpoint>(", ", serviceEndpoints)} ]");
            }
            return String.Join(", ", output);
        }
    }

    [Serializable]
    public class ServiceEndpoint
    {
        public string key;
        public string url; 

        public override string ToString() 
        {
            return "{ " + key + ": \"" + url + "\"}";
        }
    }
}