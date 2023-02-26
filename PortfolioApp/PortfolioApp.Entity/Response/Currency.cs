using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Entity.Response
{
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal BuyingRate { get; set; }
        public decimal SellingRate { get; set; }
    }
}
