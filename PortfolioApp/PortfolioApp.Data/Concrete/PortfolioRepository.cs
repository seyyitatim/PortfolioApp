using PortfolioApp.Data.Abstract;
using PortfolioApp.Data.DbContexts;
using PortfolioApp.Data.Repositories;
using PortfolioApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Data.Concrete
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
