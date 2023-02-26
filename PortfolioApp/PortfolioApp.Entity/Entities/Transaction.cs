using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Entity.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string BuyCurrencyCode { get; set; }
        public string SellCurrencyCode { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
