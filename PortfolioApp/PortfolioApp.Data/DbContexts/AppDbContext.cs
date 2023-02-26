using Microsoft.EntityFrameworkCore;
using PortfolioApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portfolio>()
                .HasData(new Portfolio {Id=1, Code = "TRY", Name = "Türk Lirası", Amount = 100000 });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
