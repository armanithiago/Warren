using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarrenAPI.Models;

namespace WarrenAPI.Services
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccount(int number);
        Account Deposit(Transaction transaction);
        Account Withdraw(Transaction transaction);
        Account Payment(Transaction transaction);
        IEnumerable<TransactionHistory> GetTransactions(int number);

    }
}
