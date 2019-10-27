using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WarrenAPI.Models;
using WarrenAPI.Services;

namespace WarrenAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("Accounts")]
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return _accountService.GetAccounts();
        }

        [HttpGet("{number}")]
        public Account GetAccount(int number)
        {
            return _accountService.GetAccount(number);
        }

        [Route("Deposit")]
        [HttpPost]
        public Account Deposit([FromBody]Transaction transaction)
        {
            return _accountService.Deposit(transaction);
        }

        [Route("Withdraw")]
        [HttpPost]
        public Account Withdraw([FromBody]Transaction transaction)
        {
            return _accountService.Withdraw(transaction);
        }

        [Route("Payment")]
        [HttpPost]
        public Account Payment([FromBody]Transaction transaction)
        {
            return _accountService.Payment(transaction);
        }

        [Route("Trasaction/{number}")]
        [HttpGet]
        public IEnumerable<TransactionHistory> Transactions(int number)
        {
            return _accountService.GetTransactions(number);
        }
    }
}
