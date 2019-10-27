using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarrenAPI.Models;

namespace WarrenAPI.Repositories
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TransactionHistory> Transactions { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TransactionHistory>()
                .Property(c => c.TransactionType)
                .HasConversion<int>();

            base.OnModelCreating(modelBuilder);

        }
    }
}
