using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ALMBank.Models.Services.Interface;
using ALMBank.Models.ViewModels;

namespace ALMBank.Models.Services
{
    public class BankRepository : IBank
    {
        private static readonly List<Customer> Customers = new List<Customer>
        {
            new Customer {CustomerID = 1, CustomerName = "Love Haglund", Account = new Account { AccountName = "Love", AccountID = 1, Balance = 500} },
            new Customer {CustomerID = 2, CustomerName = "Fredrik Rönnehag", Account = new Account { AccountName = "Fredrik", AccountID = 2, Balance = 1000}},
            new Customer {CustomerID = 3, CustomerName = "Fredrik Haglund", Account = new Account { AccountName = "Fredrik", AccountID = 3, Balance = 1500}},

        };

        public Account GetAccount(int accountId)
        {
            return Customers.SingleOrDefault(x => x.Account.AccountID == accountId)?.Account;
        }

        public List<Customer> GetCustomers() => Customers;

        public HomeViewModel getBankData(HomeViewModel model)
        {
            var customers = GetCustomers();
            model.TotalBalance = customers.Select(m => m.Account.Balance).Count();
            model.NumberOfCustomers = customers.Count();
            return model;
        }

        public TransactionViewModel Deposit(TransactionViewModel model)
        {
            model.AmountValid = false;
            model.AccountExist = false;
            var account = GetAccount(model.AccountNumber);
            if (account != null)
            {
                model.AccountExist = true;
                if (model.Amount > ((decimal) 0.01))
                {
                    model.AmountValid = true;
                    if (model.Amount > account.Balance)
                    {
                        model.AmountValid = false;
                        return model;
                    }

                    var amount = Math.Round(model.Amount, 2);
                    account.Balance = (account.Balance + amount);
                    return model;
                }
                else
                {
                    model.AmountValid = false;
                    return model;
                }

            }

            model.AccountExist = false;
            return model;

        }


        public bool Transfer(int fromAccountId, int toAccountId, decimal sum)
        {
            if (fromAccountId == toAccountId) return false;
            var accountFrom = GetAccount(fromAccountId);
            var accountTo = GetAccount(toAccountId);

            if (accountTo == null || accountFrom == null) return false;
            if (accountFrom.Balance < sum || sum <= 0) return false;

            accountFrom.Balance -= sum;
            accountTo.Balance += sum;
            return true;
        }

        public TransactionViewModel Withdraw(TransactionViewModel model)
        {
            model.AmountValid = false;
            model.AccountExist = false;
            var account = GetAccount(model.AccountNumber);

            if (account != null)
            {
                model.AccountExist = true;
                if (model.Amount > ((decimal)0.01))
                {
                    model.AmountValid = true;
                   
                        if (model.Amount > account.Balance)
                        {
                            model.AmountValid = false;
                            return model;
                        }

                        var amount = Math.Round(model.Amount, 2);
                        account.Balance = (account.Balance - amount);
                        return model;
                }
                else
                {
                    model.AmountValid = false;
                    return model;
                }

            }
            else
            {
                model.AccountExist = false;
                return model;
            
            }
        }
        
          

        }

}

