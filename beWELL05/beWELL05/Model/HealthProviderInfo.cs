using System;
using System.Collections.Generic;
using System.Text;

namespace beWELL05.Model
{
    public class HealthProvider
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string WebSite { get; set; }
        public string GeoLocation { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ProviderType { get; set; }

    }
    public class Country
    {
        public string Name { get; set; }
        public string CountryPagePath { get; set; }
    }
    public class City
    {
        public string CName { get; set; }
        public string CValue { get; set; }
    }
    public class ProviderType
    {
        public string PTDisplayName { get; set; }
        public string PTValue { get; set; }
    }
}
