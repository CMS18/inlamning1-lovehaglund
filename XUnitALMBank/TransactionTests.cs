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
        
        [Fact]
        public void Transfer_ValidAmount_ShouldUpdateBalanceCorrectly()
        {
            // Arrange
            var repo = new BankRepository();
            var accountFrom = repo.GetAccount(1);
            accountFrom.Balance = 100M;
            var accountTo = repo.GetAccount(2);
            accountTo.Balance = 100M;

            // Act
            var success = repo.Transfer(accountFrom.AccountID, accountTo.AccountID, 100M);

            // Assert
            success.ShouldBe(true);
            accountFrom.Balance.ShouldBe(0M);
            accountTo.Balance.ShouldBe(200M);
        }

        [Fact]
        public void Transfer_ExceedsLimit_TransferShouldFail()
        {
            // Arrange
            var repo = new BankRepository();
            var accountFrom = repo.GetAccount(1);
            accountFrom.Balance = 500M;
            var accountTo = repo.GetAccount(2);
            accountTo.Balance = 100M;

            // Act
            var success = repo.Transfer(accountFrom.AccountID, accountTo.AccountID, 1000M);

            // Assert
            success.ShouldBe(false);
            accountFrom.Balance.ShouldBe(500M);
            accountTo.Balance.ShouldBe(100M);
        }



        [Fact]
        public async Task Deposit_CheckBalance_ShouldBe()
        {
            //Arrange
            var repo = new BankRepository();
            var account = repo.GetAccount(1) ;
            account.Balance = 500;
            var model = new TransactionViewModel();
            model.Amount = 500;
            model.AccountNumber = 1;

            //Act
            repo.Deposit(model);

            //Assert
            account.Balance.ShouldBe(1000);

        }
        [Fact]
        public async Task Withdraw_CheckBalance_ShouldBe()
        {
            //Arrange
            var repo = new BankRepository();
            var account = repo.GetAccount(1);
            account.Balance = 500;

            var model = new TransactionViewModel();
            model.Amount = 500;
            model.AccountNumber = 1;

            //Act
            repo.Withdraw(model);
            //Assert

            account.Balance.ShouldBe(0);

        }
        [Fact]
        public async Task Withdraw_CheckBalance_InvalidAmount()
        {
            //Arrange
            var repo = new BankRepository();
            var account = repo.GetAccount(1);
            account.Balance = 500;
            var model = new TransactionViewModel();
            model.Amount = 1000;
            model.AccountNumber = 1;

            //Act
            repo.Withdraw(model);

            //Assert
            model.AmountValid.ShouldBe(false);
            account.Balance.ShouldBe(500);

        }
    }
}
