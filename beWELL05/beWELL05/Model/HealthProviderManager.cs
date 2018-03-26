using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace beWELL05.Model
{
    public class HealthProviderManager
    {
        #region Allianze Source
        //const string baseUrl = "https://apps.allianzworldwidecare.com/poi/";
        //public async Task<List<Country>> GetCountryList()
        //{
        //    HtmlAgilityPack.HtmlNodeCollection countriesNode = GetHtmlNodeCollection("hospital-doctor-and-health-practitioner-finder", "//a[@class='blocking-ui btn-link zero_left_margin']");

        //    List<Country> result = new List<Country>();

        //    foreach (var countryItem in countriesNode)
        //    {
        //        result.Add(new Country { Name = countryItem.InnerText, CountryPagePath = countryItem.Attributes["href"].Value });
        //    }
        //    return result;

        //}
        //public async Task<List<City>> GetCityList(string urlPath)
        //{
        //    HtmlAgilityPack.HtmlNodeCollection cityNodes = GetHtmlNodeCollection(urlPath, "//select[@id='city']/option");
        //    List<City> result = new List<City>();
        //    foreach (var cityItem in cityNodes)
        //    {
        //        result.Add(new City { CName = cityItem.InnerText, CValue = cityItem.InnerText });
        //    }
        //    return result;
        //}
        //public async Task<List<HealthProvider>> GetHealthProviders(string country="Qatar", string city="Doha", string providerType = "HOSPITALS")
        //{
        //    string path = "hospital-doctor-and-health-practitioner-finder?TRANS=Hospitals%2C+Doctors+and+Health+Practitioners+in+" + city + "%2C" + country + "&CON=World&COUNTRY=" + country + "&CITY=" + city + "&PROVTYPE=" + providerType;
        //    HtmlAgilityPack.HtmlNodeCollection Providerlist = GetHtmlNodeCollection(path, "//table[@class='table']");
        //    List<HealthProvider> result = new List<HealthProvider>();
        //    foreach (var providerItem in Providerlist)
        //    {
        //        result.Add(new HealthProvider { Name = HttpUtility.HtmlDecode(providerItem.ChildNodes[1].InnerText.Trim()) });
        //    }
        //    return result;

        //}
        //public async Task<List<ProviderType>> GetProviderTypes()
        //{
        //    return new List<ProviderType> { new ProviderType { PTDisplayName = "Hospitals", PTValue = "HOSPITALS" }, new ProviderType { PTDisplayName = "Doctors and Health Practitioners", PTValue = "PRACTITIONERS" } };
        //}
        //public static HtmlAgilityPack.HtmlNodeCollection GetHtmlNodeCollection(string UrlPath, string HtmlTagSelection)
        //{
        //    HtmlAgilityPack.HtmlDocument doc = GetHtmlDoc(UrlPath);
        //    HtmlAgilityPack.HtmlNodeCollection result = doc.DocumentNode.SelectNodes(HtmlTagSelection);
        //    return result;
        //}
        //public static HtmlAgilityPack.HtmlDocument GetHtmlDoc(string UrlPath)
        //{
        //    string url = baseUrl + HttpUtility.HtmlDecode(UrlPath);
        //    HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
        //    HtmlAgilityPack.HtmlDocument doc = web.Load(url);
        //    return doc;
        //}
        #endregion

        #region OfflineJson
        private const string Filename = "SelectedCountries.min.json";
        public static IStreamLoader Loader { get; set; }

        public static async Task<IEnumerable<HealthProvider>> GetHealthProvidersAsync()
        {
            using (var reader = new StreamReader(OpenData()))
            {
                return JsonConvert.DeserializeObject<List<HealthProvider>>(await reader.ReadToEndAsync());
            }
        }

        private static Stream OpenData()
        {
            if (Loader == null)
                throw new Exception("Must set platform Loader before calling Load.");
            return Loader.GetStreamForFilename(Filename);
        }
        #endregion

    }
}
