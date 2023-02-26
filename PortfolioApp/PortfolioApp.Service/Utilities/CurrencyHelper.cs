using PortfolioApp.Entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PortfolioApp.Service.Utilities
{
    public static class CurrencyHelper
    {
        private static string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
        public static TCMBCurrenciesResponse GetCurrency()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            var currencies = xmlDoc.SelectNodes("/Tarih_Date/Currency");
            TCMBCurrenciesResponse response = new();

            foreach (XmlNode currency in currencies)
            {
                response.Currencies.Add(new()
                {
                    CurrencyCode = currency.Attributes?.GetNamedItem("CurrencyCode")?.Value,
                    CurrencyName = currency.ChildNodes[1]?.InnerText,
                    BuyingRate = string.IsNullOrEmpty(currency.ChildNodes[3]?.InnerText) ? 0 : Convert.ToDecimal(currency.ChildNodes[3]?.InnerText),
                    SellingRate = string.IsNullOrEmpty(currency.ChildNodes[4]?.InnerText) ? 0 : Convert.ToDecimal(currency.ChildNodes[4]?.InnerText)
                });
            }

            return response;
        }

        public static CurrencyCodesResponse GetCurrencyCodes()
        {
            var currencies = GetCurrency();
            return new()
            {
                CurrencyCodes = currencies.Currencies.Select(x =>
                    new CurrencyCode
                    {
                        Code = x.CurrencyCode,
                        Name = x.CurrencyName
                    }
                ).ToList()
            };
        }

        public static Currency GetCurrency(string code)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            var currency = xmlDoc.SelectSingleNode($"/Tarih_Date/Currency[@CurrencyCode='{code}']");

            if (currency == null) return new();

            return new()
            {
                Code = currency.Attributes?.GetNamedItem("CurrencyCode")?.Value,
                Name = currency.ChildNodes[1]?.InnerText,
                BuyingRate = string.IsNullOrEmpty(currency.ChildNodes[3]?.InnerText) ? 0 : Convert.ToDecimal(currency.ChildNodes[3]?.InnerText),
                SellingRate = string.IsNullOrEmpty(currency.ChildNodes[4]?.InnerText) ? 0 : Convert.ToDecimal(currency.ChildNodes[4]?.InnerText)
            };

        }
        public static bool CheckCurrencyCode(string code)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            var currency = xmlDoc.SelectSingleNode($"/Tarih_Date/Currency[@CurrencyCode='{code}']");

            return currency == null ? false : true;

        }

        public static decimal GetBuyingRate(string code)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            var currency = xmlDoc.SelectSingleNode($"/Tarih_Date/Currency[@CurrencyCode='{code}']");

            return currency == null ? 0 : string.IsNullOrEmpty(currency.ChildNodes[3]?.InnerText) ? 0 : Convert.ToDecimal(currency.ChildNodes[3]?.InnerText);

        }
    }
}
