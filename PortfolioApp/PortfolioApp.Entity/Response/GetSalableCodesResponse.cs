using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Entity.Response
{
    public class GetSalableCodesResponse
    {
        public List<CurrencyCode> CurrencyCodes { get; set; }
    }
}
