using BankWeb.models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankWeb.Controllers
{
    [ApiController]
    [Route("api/account/V1")]
    [EnableCors("AllowAll")]
    public class AccountController : ControllerBase
    {
        private readonly static Account _defaultAccount = new Account(1, 1500);

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            this._logger = logger;
            AccountController._defaultAccount.Currency = "Euro";
        }

        [HttpGet]
        public Account Get()
        {
            this._logger.LogInformation("getting the default account");
            return AccountController._defaultAccount;
        }

        [HttpGet("deposit")]
        public Account Deposit(double amount)
        {
            this._logger.LogInformation($"Deposing {amount}");
            AccountController._defaultAccount.Deposit(amount);
            return AccountController._defaultAccount;
        }

        [HttpGet("withdraw")]
        public Account Withdraw(double amount)
        {
            var message = $"Withdrawing {amount}";

            this._logger.LogInformation(message);
            AccountController._defaultAccount.Withdraw(amount);
            return AccountController._defaultAccount;
        }
    }
}
