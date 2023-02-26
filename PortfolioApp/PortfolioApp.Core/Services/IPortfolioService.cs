using PortfolioApp.Entity.Request;
using PortfolioApp.Entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Core.Services
{
    public interface IPortfolioService
    {
        public Task<PortfolioResponse> GetPortfolios();
        public Task<GetSalableCodesResponse> GetSalableCodes();
        public Task<BuyCurrencyResponse> BuyCurrencyAsync(BuyCurrencyRequest request);
        public Task<SellCurrencyResponse> SellCurrency(SellCurrencyRequest request);
        public Task Reset();
    }
}
