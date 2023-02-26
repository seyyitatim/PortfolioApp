using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Entity.Response
{
    public class CurrencyCodesResponse
    {
        public List<CurrencyCode> CurrencyCodes { get; set; }
    }

    public class CurrencyCode
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
