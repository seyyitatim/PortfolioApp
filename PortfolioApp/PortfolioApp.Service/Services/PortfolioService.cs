using Microsoft.EntityFrameworkCore;
using PortfolioApp.Core.Repository;
using PortfolioApp.Core.Services;
using PortfolioApp.Data.Abstract;
using PortfolioApp.Entity.Constants;
using PortfolioApp.Entity.Entities;
using PortfolioApp.Entity.Request;
using PortfolioApp.Entity.Response;
using PortfolioApp.Service.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Service.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PortfolioService(IPortfolioRepository portfolioRepository, IUnitOfWork unitOfWork, ITransactionRepository transactionRepository)
        {
            _portfolioRepository = portfolioRepository;
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepository;
        }

        public async Task<BuyCurrencyResponse> BuyCurrencyAsync(BuyCurrencyRequest request)
        {
            if (!CurrencyHelper.CheckCurrencyCode(request.Code) && !CheckAmount(request.Amount)) return new() { IsSucces = false };

            var currency = CurrencyHelper.GetCurrency(request.Code);

            var total = currency.BuyingRate * request.Amount;
            var sellingAccount = _portfolioRepository.Where(x => x.Code == "TRY").First();

            if (!CheckTotalAmount(sellingAccount, total)) return new() { IsSucces = false };

            var buyingAccount = _portfolioRepository.Where(x => x.Code == currency.Code).FirstOrDefault();
            if (buyingAccount != null)
            {
                buyingAccount.Amount += request.Amount;
            }
            else
            {
                await _portfolioRepository.AddAsync(new()
                {
                    Code = request.Code,
                    Amount = request.Amount,
                    Name = currency.Name
                });
            }

            sellingAccount.Amount -= total;

            await SaveTransaction(request.Code, "TRY", currency.BuyingRate, request.Amount);

            await _unitOfWork.CommitAsync();

            return new() { IsSucces = true };
        }

        private async Task SaveTransaction(string buyingCurrencyCode, string sellingCurrencyCode, decimal buyingRate, decimal amount)
        {
            await _transactionRepository.AddAsync(new()
            {
                BuyCurrencyCode = buyingCurrencyCode,
                SellCurrencyCode = sellingCurrencyCode,
                Rate = buyingRate,
                Amount = amount,
                Date = DateTime.Now
            });
        }

        private bool CheckTotalAmount(Portfolio account, decimal amount)
        {
            return account.Amount >= amount;
        }

        private bool CheckAmount(decimal amount)
        {
            return amount >= 0;
        }

        public async Task<PortfolioResponse> GetPortfolios()
        {
            return new() { Portfolios = await _portfolioRepository.GetAllAsync() };
        }

        public async Task<SellCurrencyResponse> SellCurrency(SellCurrencyRequest request)
        {
            if (!CurrencyHelper.CheckCurrencyCode(request.Code) && !CheckAmount(request.Amount)) return new() { IsSucces = false };

            var currency = CurrencyHelper.GetCurrency(request.Code);

            var sellingAccount = _portfolioRepository.Where(x => x.Code == request.Code).FirstOrDefault();

            if (sellingAccount == null) return new() { IsSucces = false };

            if (sellingAccount.Amount < request.Amount) return new() { IsSucces = false };

            var buyingAccount = _portfolioRepository.Where(x => x.Code == "TRY").First();

            var total = request.Amount * currency.SellingRate;

            buyingAccount.Amount += total;
            sellingAccount.Amount -= request.Amount;

            await SaveTransaction("TRY", request.Code, currency.SellingRate, request.Amount);

            await _unitOfWork.CommitAsync();

            return new() { IsSucces = true };
        }

        public async Task<GetSalableCodesResponse> GetSalableCodes()
        {
            var datas = await _portfolioRepository.Where(x => x.Code != "TRY").ToListAsync();
            return new() { CurrencyCodes = datas.Select(x => new CurrencyCode { Code = x.Code, Name = x.Name }).ToList() };
        }

        public async Task Reset()
        {
            _portfolioRepository.Reset(TableNames.Portfolio);
            _portfolioRepository.Reset(TableNames.Transaction);

            await _portfolioRepository.AddAsync(new()
            {
                Code = "TRY",
                Name = "Türk Lirası",
                Amount = 100000
            });

            await _unitOfWork.CommitAsync();
        }
    }
}
