using System;
using System.Linq;
using System.Threading.Tasks;
using ALMBank.Models.Services;
using ALMBank.Models.ViewModels;
using Shouldly;
using Xunit;

namespace XUnitALMBank
{
    public class TransactionTests : Exceptions
    {

        [Fact]
        public async Task Deposit_CheckBalance_ShouldBe()
        {
            //Arrange
            
            var model = new TransactionViewModel();
            model.Amount = 500;
            model.AccountNumber = 1;
            var repo = new BankRepository();

            //Act
            repo.Deposit(model);
            var account = context.CustomerList.SingleOrDefault(m => m.Account.AccountID == 1);
            account.Account.Balance = (account.Account.Balance + model.Amount);

            //Assert
            
            context.CustomerList.Single(a => a.Account.AccountID == 1).Account.Balance.ShouldBe(1000);

        }
        [Fact]
        public async Task Withdraw_CheckBalance_ShouldBe()
        {
            //Arrange

            var model = new TransactionViewModel();
            model.Amount = 500;
            model.AccountNumber = 1;
            var repo = new BankRepository();

            //Act
            repo.Deposit(model);
            var account = context.CustomerList.SingleOrDefault(m => m.Account.AccountID == 1);
            account.Account.Balance = (account.Account.Balance - model.Amount);

            //Assert

            context.CustomerList.Single(a => a.Account.AccountID == 1).Account.Balance.ShouldBe(0);

        }
        [Fact]
        public async Task Withdraw_CheckBalance_InvalidAmount()
        {
            //Arrange

            var model = new TransactionViewModel();
            model.Amount = 1000;
            model.AccountNumber = 1;
            var repo = new BankRepository();

            //Act
            var account = context.CustomerList.SingleOrDefault(m => m.Account.AccountID == 1);
            if (model.Amount > account.Account.Balance)
            {
                throw new NotEnoughMoneyException();
            }

                account.Account.Balance = (account.Account.Balance - model.Amount);

            //Assert

            context.CustomerList.Single(a => a.Account.AccountID == 1).Account.Balance.ShouldBe(0);

        }
    }
}
