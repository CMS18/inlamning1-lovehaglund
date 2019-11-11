using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMBank.Models.Services.Interface;
using ALMBank.Models.ViewModels;

namespace ALMBank.Models.Services
{
    public class BankRepository : IBank
    {
        public CustomerAccountsViewModel GetCustomer(CustomerAccountsViewModel model)
        {
            var customer1 = new Customer
            {
                CustomerName = "Love Haglund",
                CustomerID = 1,
                Account = new Account
                {
                    AccountName = "Love",
                    Balance = 500,
                    AccountID = 1
                }
            };
            var customer2 = new Customer
            {
                CustomerName = "Fredrik Rönnehag",
                CustomerID = 2,
                Account = new Account
                {
                    AccountName = "Fredrik",
                    Balance = 1000,
                    AccountID = 2
                }
            };
            var customer3 = new Customer
            {
                CustomerName = "Fredrik Haglund",
                CustomerID = 3,
                Account = new Account
                {
                    AccountName = "Fredrik",
                    Balance = 1500,
                    AccountID = 3
                }
            };
            model.CustomerList.Add(customer1);
            model.CustomerList.Add(customer2);
            model.CustomerList.Add(customer3);
            return model;
        }
      
    }
}
