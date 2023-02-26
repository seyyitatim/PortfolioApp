using PortfolioApp.Core.Repository;
using PortfolioApp.Core.Services;
using PortfolioApp.Data.Abstract;
using PortfolioApp.Entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;
        private IUnitOfWork _unitOfWork;

        public TransactionService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TransactionsResponse> GetTransactions()
        {
            return new() { Transactions = await _transactionRepository.GetAllAsync() };
        }
    }
}
