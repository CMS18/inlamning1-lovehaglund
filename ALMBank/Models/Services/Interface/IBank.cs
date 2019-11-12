using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMBank.Models.ViewModels;

namespace ALMBank.Models.Services.Interface
{
    public interface IBank
    {
        TransactionViewModel Withdraw(TransactionViewModel model);
        TransactionViewModel Deposit(TransactionViewModel model);
        HomeViewModel getBankData(HomeViewModel model);
        List<Customer> GetCustomers();
        Account GetAccount(int accountId);
        bool Transfer(int fromAccountId, int toAccountId, decimal sum);

    }
}
