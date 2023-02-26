using Microsoft.Extensions.DependencyInjection;
using PortfolioApp.Core.Repository;
using PortfolioApp.Core.Services;
using PortfolioApp.Data.Abstract;
using PortfolioApp.Data.Concrete;
using PortfolioApp.Data.Repositories;
using PortfolioApp.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Service.Registrations
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPortfolioService, PortfolioService>();
            services.AddScoped<ITransactionService, TransactionService>();

            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();


            return services;
        }
    }
}
