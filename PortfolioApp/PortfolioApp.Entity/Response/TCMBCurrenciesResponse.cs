using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Entity.Response
{
    public class TCMBCurrenciesResponse
    {
        public TCMBCurrenciesResponse()
        {
            Currencies = new();
        }
        public List<TCMBCurrency> Currencies { get; set; }
    }

    public class TCMBCurrency
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public decimal BuyingRate { get; set; }
        public decimal SellingRate { get; set; }
    }
}
