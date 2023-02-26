using PortfolioApp.Core.Repository;
using PortfolioApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Data.Abstract
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
    }
}
