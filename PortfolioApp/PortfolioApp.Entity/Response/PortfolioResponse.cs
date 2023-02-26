using PortfolioApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Entity.Response
{
    public class PortfolioResponse
    {
        public IEnumerable<Portfolio> Portfolios { get; set; }
    }
}
