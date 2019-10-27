using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarrenAPI.Enums;
using WarrenAPI.Models;
using WarrenAPI.Repositories;

namespace WarrenAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly AccountContext _context;
        public AccountService(AccountContext context)
        {
            _context = context;
        }

        public Account GetAccount(int number)
        {
            return _context.Accounts.Where(x => x.Number == number).FirstOrDefault();
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }
        public Account Deposit(Transaction transaction)
        {
            var account = _context.Accounts.Where(x => x.Number == transaction.AccountNumber).FirstOrDefault();
            account.Value += transaction.Value;
            var transactionHistory = new TransactionHistory { AccountNumber = account.Number, TransactionType = TransactionType.Deposit, TransactionTime = DateTime.Now };
            _context.Add(transactionHistory);
            _context.SaveChanges();
            return account;
        }

        public Account Payment(Transaction transaction)
        {
            var account = _context.Accounts.Where(x => x.Number == transaction.AccountNumber).FirstOrDefault();
            if(account.Value >= transaction.Value)
            {
                account.Value -= transaction.Value;
                var transactionHistory = new TransactionHistory { AccountNumber = account.Number, TransactionType = TransactionType.Payment, TransactionTime = DateTime.Now };
                _context.Add(transactionHistory);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Saldo insuficiente.");
            }
            return account;
        }

        public Account Withdraw(Transaction transaction)
        {
            var account = _context.Accounts.Where(x => x.Number == transaction.AccountNumber).FirstOrDefault();
            if (account.Value >= transaction.Value)
            {
                account.Value -= transaction.Value;
                var transactionHistory = new TransactionHistory { AccountNumber = account.Number, TransactionType = TransactionType.Withdraw, TransactionTime = DateTime.Now };
                _context.Add(transactionHistory);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Saldo insuficiente.");
            }
            return account;
        }

        public IEnumerable<TransactionHistory> GetTransactions(int number)
        {
            return _context.Transactions.Where(x => x.AccountNumber == number).ToList();
        }
    }
}
