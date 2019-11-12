using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMBank.Models;
using ALMBank.Models.Services;
using ALMBank.Models.ViewModels;
using Shouldly;
using Xunit;

namespace XUnitALMBank
{
    public class TransactionTests : Exceptions
    {
        private static List<Customer> context;
        public TransactionTests()
        {
            if (context == null || context.Count == 0)
            {
            context = CustomerAccountsViewModel.CustomerList = BankRepository.GetCustomers();

            }
        }

        [Fact]
        public async Task Deposit_CheckBalance_ShouldBe()
        {
            //Arrange
            var account = context.SingleOrDefault(m => m.Account.AccountID == 1);
            account.Account.Balance = 500;
            var model = new TransactionViewModel();
            model.Amount = 500;
            model.AccountNumber = 1;
            var repo = new BankRepository();

            //Act
            repo.Deposit(model);

            //Assert
            
            context.Single(a => a.Account.AccountID == 1).Account.Balance.ShouldBe(1000);

        }
        [Fact]
        public async Task Withdraw_CheckBalance_ShouldBe()
        {
            //Arrange
            var account = context.SingleOrDefault(m => m.Account.AccountID == 1);
            account.Account.Balance = 500;
            
            var model = new TransactionViewModel();
            model.Amount = 500;
            model.AccountNumber = 1;
            var repo = new BankRepository();

            //Act
            repo.Withdraw(model);
            //Assert

            context.Single(a => a.Account.AccountID == 1).Account.Balance.ShouldBe(0);

        }
        [Fact]
        public async Task Withdraw_CheckBalance_InvalidAmount()
        {
            //Arrange
            var repo = new BankRepository();
            var account = context.SingleOrDefault(m => m.Account.AccountID == 1);
            account.Account.Balance = 500;
            var model = new TransactionViewModel();
            model.Amount = 1000;
            model.AccountNumber = 1;

            //Act
            repo.Withdraw(model);

            //Assert
            model.AmountValid.ShouldBe(false);
            account.Account.Balance.ShouldBe(500);

        }
    }
}
