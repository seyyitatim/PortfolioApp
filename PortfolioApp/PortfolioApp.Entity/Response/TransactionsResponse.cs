using PortfolioApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Entity.Response
{
    public class TransactionsResponse
    {
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
