using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using Serenity.Data;
using System;
using WarrenAPI.Models;
using WarrenAPI.Repositories;
using WarrenAPI.Services;

namespace WarrenTest
{
    [TestClass]
    public class AccountTest
    {
        private IAccountService _accountService;
        private AccountContext _dbContext;
        private Transaction ERROR_NEGATIVE_NUMBER = new Transaction() { AccountNumber = 1234568, Value = -100 };
        private Transaction ERROR_WITHOUT_ACCOUNT_NUMBER = new Transaction() { AccountNumber = 0, Value = 100 };
        private Transaction SUCCESS_DEPOSIT = new Transaction() { AccountNumber = 11111111, Value = 100 };
        private Transaction SUCCESS_WITHDRAW = new Transaction() { AccountNumber = 22222222, Value = 100 };
        private Transaction SUCCESS_PAYMENT = new Transaction() { AccountNumber = 33333333, Value = 100 };
        private Transaction INSUFFICIENT_FUNDS_WITHDRAW = new Transaction() { AccountNumber = 44444444, Value = 1000 };
        private Transaction INSUFFICIENT_FUNDS_PAYMENT = new Transaction() { AccountNumber = 55555555, Value = 1000 };

        public AccountTest()
        {
            _dbContext = new AccountContextFactory().GetAccountContext();
            _accountService = new AccountService(_dbContext);
        }

        [TestMethod]
        public void DepositErrorNegativeNumber()
        {
            Exception expectedException = null;
            try
            {
                _accountService.Deposit(ERROR_NEGATIVE_NUMBER);
            }
            catch(Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsTrue(expectedException != null && expectedException.Message == "A transação deve possuir um valor numérico e positivo.");
        }

        [TestMethod]
        public void WithdrawErrorNegativeNumber()
        {
            Exception expectedException = null;
            try
            {
                _accountService.Withdraw(ERROR_NEGATIVE_NUMBER);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsTrue(expectedException != null && expectedException.Message == "A transação deve possuir um valor numérico e positivo.");
        }

        [TestMethod]
        public void PaymentErrorNegativeNumber()
        {
            Exception expectedException = null;
            try
            {
                _accountService.Payment(ERROR_NEGATIVE_NUMBER);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsTrue(expectedException != null && expectedException.Message == "A transação deve possuir um valor numérico e positivo.");
        }

        [TestMethod]
        public void DepositErrorAccountWithoutNumber()
        {
            Exception expectedException = null;
            try
            {
                _accountService.Deposit(ERROR_WITHOUT_ACCOUNT_NUMBER);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsTrue(expectedException != null && expectedException.Message == "Número da conta deve ser informado.");
        }

        [TestMethod]
        public void WithdrawErrorAccountWithoutNumber()
        {
            Exception expectedException = null;
            try
            {
                _accountService.Withdraw(ERROR_WITHOUT_ACCOUNT_NUMBER);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsTrue(expectedException != null && expectedException.Message == "Número da conta deve ser informado.");
        }

        [TestMethod]
        public void PaymentErrorAccountWithoutNumber()
        {
            Exception expectedException = null;
            try
            {
                _accountService.Payment(ERROR_WITHOUT_ACCOUNT_NUMBER);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsTrue(expectedException != null && expectedException.Message == "Número da conta deve ser informado.");
        }

        [TestMethod]
        public void DepositSuccess()
        {
            Account account = new Account() { Number = 11111111, Value = 1000 };
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            Exception unexpectedException = null;
            Account successAccount = null;
            try
            {
                successAccount = _accountService.Deposit(SUCCESS_DEPOSIT);
            }
            catch (Exception ex)
            {
                unexpectedException = ex;
            }
            Assert.IsTrue(successAccount.Value == 1100);
        }

        [TestMethod]
        public void WithdrawSuccess()
        {
            Account account = new Account() { Number = 22222222, Value = 1000 };
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

            Exception unexpectedException = null;
            Account successAccount = null;
            try
            {
                successAccount = _accountService.Withdraw(SUCCESS_WITHDRAW);
            }
            catch (Exception ex)
            {
                unexpectedException = ex;
            }
            Assert.IsTrue(successAccount.Value == 900);
        }

        [TestMethod]
        public void PaymentSuccess()
        {
            Account account = new Account() { Number = 33333333, Value = 1000 };
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

            Exception unexpectedException = null;
            Account successAccount = null;
            try
            {
                successAccount = _accountService.Payment(SUCCESS_PAYMENT);
            }
            catch (Exception ex)
            {
                unexpectedException = ex;
            }
            Assert.IsTrue(successAccount.Value == 900);
        }

        [TestMethod]
        public void WithdrawInsufficientFunds()
        {
            Account account = new Account() { Number = 44444444, Value = 100 };
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

            Exception expectedException = null;
            Account successAccount = null;
            try
            {
                successAccount = _accountService.Payment(INSUFFICIENT_FUNDS_WITHDRAW);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsTrue(expectedException != null && expectedException.Message == "Saldo insuficiente.");
        }

        [TestMethod]
        public void PaymentInsufficientFunds()
        {
            Account account = new Account() { Number = 55555555, Value = 100 };
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

            Exception expectedException = null;
            Account successAccount = null;
            try
            {
                successAccount = _accountService.Payment(INSUFFICIENT_FUNDS_PAYMENT);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.IsTrue(expectedException != null && expectedException.Message == "Saldo insuficiente.");
        }
    }
}
