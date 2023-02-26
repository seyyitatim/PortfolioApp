using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Entity.Request
{
    public class SellCurrencyRequest
    {
        public string Code { get; set; }
        public decimal Amount { get; set; }
    }
}
