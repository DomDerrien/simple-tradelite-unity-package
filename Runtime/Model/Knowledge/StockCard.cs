using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.KnowledgeScope {
    [Serializable]
    public class StockCard : BaseModel {
        public string name;
        public string description;
        public string logo;
        public string sector;
        public string industry;
        public string symbol;
        public string exchange;
        public string[] locales;
        public Address hqAddress;
        public Quote[] declaredDividends;
        public Quote[] monthlyQuotePrices;
        public Quote[] monthlyMarketCapitalizations;

        public override string ToString() {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);
            output.Add($"name: `{name}`");
            output.Add($"name: `{description}`");
            output.Add($"logo: `{logo}`");
            output.Add($"industry: `{sector}`");
            output.Add($"industry: `{industry}`");
            output.Add($"symbol: `{symbol}`");
            output.Add($"exchange: `{exchange}`");
            output.Add($"locales: ({locales.Length}) {(locales.Length == 0 ? "[]" : $"[ `{String.Join<string>("`, `", locales)}` ]")}");
            output.Add($"hqAddress: {hqAddress}");
            output.Add(declaredDividends == null ? "declaredDividends (0)" : $"declaredDividends: ({declaredDividends.Count()}) [ {String.Join<Quote>(", ", declaredDividends)} ]");
            output.Add(monthlyQuotePrices == null ? "monthlyQuotePrices (0)" : $"monthlyQuotePrices: ({monthlyQuotePrices.Count()}) [ {String.Join<Quote>(", ", monthlyQuotePrices)} ]");
            output.Add(monthlyMarketCapitalizations == null ? "monthlyMarketCapitalizations (0)" : $"monthlyMarketCapitalizations: ({monthlyMarketCapitalizations.Count()}) [ {String.Join<Quote>(", ", monthlyMarketCapitalizations)} ]");
            return String.Join(", ", output);
        }
    }

    public class Address : BaseModel {
        public string country;
        public string address;
        public string street;
        public string street2;
        public string city;
        public string stateOrProvince;

        public override string ToString() {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);
            if (!string.IsNullOrEmpty(country)) output.Add($"country: `{country}`");
            if (!string.IsNullOrEmpty(address)) output.Add($"address: `{address}`");
            if (!string.IsNullOrEmpty(street)) output.Add($"street: `{street}`");
            if (!string.IsNullOrEmpty(street2)) output.Add($"street2: `{street2}`");
            if (!string.IsNullOrEmpty(city)) output.Add($"city: `{city}`");
            if (!string.IsNullOrEmpty(stateOrProvince)) output.Add($"stateOrProvince: `{stateOrProvince}`");
            return String.Join(", ", output);
        }
    }

    public class Role : BaseModel {
        public RoleType type = RoleType.CEO;
        public string fullname = "unknown";
        public string nationality;
        public Address address;

        public override string ToString() {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);
            output.Add($"type: `{type}`");
            output.Add($"fullname: `{fullname}`");
            if (!string.IsNullOrEmpty(nationality)) output.Add($"nationality: `{nationality}`");
            if (address != null) output.Add($"address: {{ {address} }}");
            return String.Join(", ", output);
        }
    }

    public enum RoleType {
        CEO,
        CFO,
        President,
        VicePresident,
        ManagingDirector,
        BoardPresident,
        BoardDirector
    }

    public class Quote : BaseModel {
        public string date;
        public double value;

        public override string ToString() {
            List<string> output = new List<string>();
            string baseToString = base.ToString();
            if (!string.IsNullOrEmpty(baseToString)) output.Add(baseToString);
            output.Add($"date: `{date}`");
            output.Add($"value: {value}");
            return String.Join(", ", output);
        }
    }
}