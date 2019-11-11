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
                Account = new Account
                {
                    AccountName = "Love",
                    Balance = 500
                }
            };
            var customer2 = new Customer
            {
                CustomerName = "Fredrik Rönnehag",
                Account = new Account
                {
                    AccountName = "Fredrik",
                    Balance = 1000
                }
            };
            model.CustomerList.Add(customer1);
            model.CustomerList.Add(customer2);
            return model;
        }
      
    }
}
