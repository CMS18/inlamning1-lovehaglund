using System;
using System.Collections.Generic;
using System.Text;
using ALMBank.Models;

namespace XUnitALMBank
{
    public static class context
    {
        public static List<Customer> CustomerList { get; set; }

        static context()
        {
            CustomerList = new List<Customer>();
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
            CustomerList.Add(customer1);
            CustomerList.Add(customer2);
            CustomerList.Add(customer3);
        }

    }
}
