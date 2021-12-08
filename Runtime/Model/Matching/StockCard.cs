using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Tradelite.SDK.Model;

namespace Tradelite.SDK.Model.MatchingScope
{
    [Serializable]
    public class StockCard: BaseModel
    {
        public string corporateName;
        public string tradeName;
        public string industry;
        public string stockId;
        public string[] exchanges;
        public Address principalAddress;
        public Quote[] declaredDividends;
        public Quote[] monthlyQuotePrices;
        public Quote[] monthlyMarketCapitalizations;

        public override string ToString()
        {
            List<string> output = new List<string>();
            output.Add(base.ToString());
            output.Add($"corporateName: {corporateName}");
            output.Add($"tradeName: {tradeName}");
            output.Add($"industry: {industry}");
            output.Add($"stockId: {stockId}");
            output.Add($"locales: ({exchanges.Count()}) [ {String.Join<string>(", ", exchanges)} ]");
            output.Add($"principalAddress: {principalAddress}");
            output.Add($"locales: ({declaredDividends.Count()}) [ {String.Join<Quote>(", ", declaredDividends)} ]");
            output.Add($"locales: ({monthlyQuotePrices.Count()}) [ {String.Join<Quote>(", ", monthlyQuotePrices)} ]");
            output.Add($"locales: ({monthlyMarketCapitalizations.Count()}) [ {String.Join<Quote>(", ", monthlyMarketCapitalizations)} ]");
            return String.Join(", ", output);
        }
    }

    public class Address: BaseModel
    {
        public string country;
        public string street;
        public string street2;
        public string city;
        public string stateOrProvince;

        public override string ToString()
        {
            List<string> output = new List<string>();
            output.Add(base.ToString());
            output.Add($"country: {country}");
            output.Add($"street: {street}");
            output.Add($"street2: {street2}");
            output.Add($"city: {city}");
            output.Add($"stateOrProvince: {stateOrProvince}");
            return String.Join(", ", output);
        }
    }

    public class Role: BaseModel
    {
        public RoleType type;
        public string fullname;
        public string nationality;
        public Address address;

        public override string ToString()
        {
            List<string> output = new List<string>();
            output.Add(base.ToString());
            output.Add($"type: {type}");
            output.Add($"fullname: {fullname}");
            output.Add($"nationality: {nationality}");
            output.Add($"address: {address}");
            return String.Join(", ", output);
        }
    }

    public enum RoleType
    {
        CEO,
        CFO,
        President,
        VicePresident,
        ManagingDirector,
        BoardPresident,
        BoardDirector
    }

    public class Quote: BaseModel
    {
        public string date;
        public float value;

        public override string ToString()
        {
            List<string> output = new List<string>();
            output.Add(base.ToString());
            output.Add($"date: {date}");
            output.Add($"value: {value}");
            return String.Join(", ", output);
        }
    }
}