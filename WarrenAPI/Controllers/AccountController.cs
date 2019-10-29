using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WarrenAPI.Models;
using WarrenAPI.Services;
using System.Net.Http;
using System.Net;

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
        public IActionResult Get()
        {
            try
            {
                var response = _accountService.GetAccounts();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{number}")]
        public IActionResult GetAccount(int number)
        {
            try
            {
                var response = _accountService.GetAccount(number);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Deposit")]
        [HttpPost]
        public IActionResult Deposit([FromBody]Transaction transaction)
        {
            try
            {
                
                var response = _accountService.Deposit(transaction);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Withdraw")]
        [HttpPost]
        public IActionResult Withdraw([FromBody]Transaction transaction)
        {
            try
            {
                var response = _accountService.Withdraw(transaction);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [Route("Payment")]
        [HttpPost]
        public IActionResult Payment([FromBody]Transaction transaction)
        {
            try
            {
                var response = _accountService.Payment(transaction);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Trasaction/{number}")]
        [HttpGet]
        public IActionResult Transactions(int number)
        {
            try
            {
                var response = _accountService.GetTransactions(number);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
