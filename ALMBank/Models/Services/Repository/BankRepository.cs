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
        public static List<Customer> GetCustomers()
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
            CustomerAccountsViewModel.CustomerList.Add(customer1);
            CustomerAccountsViewModel.CustomerList.Add(customer2);
            CustomerAccountsViewModel.CustomerList.Add(customer3);
            return CustomerAccountsViewModel.CustomerList;
        }

        public TransactionViewModel Deposit(TransactionViewModel model)
        {
            model.AmountValid = false;
            model.AccountExist = false;
            if (CustomerAccountsViewModel.CustomerList.Exists(m => m.Account.AccountID == model.AccountNumber))
            {
                model.AccountExist = true;
                if (model.Amount > ((decimal)0.01))
                {
                    model.AmountValid = true;
                    var accounts = CustomerAccountsViewModel.CustomerList.Select(c => c.Account.AccountID);
                    if (accounts.Contains(model.AccountNumber))
                    {
                        var account = CustomerAccountsViewModel.CustomerList.SingleOrDefault(m => m.Account.AccountID == model.AccountNumber);
                        if (model.Amount > account.Account.Balance)
                        {
                            model.AmountValid = false;
                            return model;
                        }

                        var amount = Math.Round(model.Amount, 2);
                        account.Account.Balance = (account.Account.Balance + amount);
                        return model;
                    }
                    else return null;

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

        private Account GetAccount(int accountId)
        {
            return CustomerAccountsViewModel.CustomerList.SingleOrDefault(x => x.Account.AccountID == accountId)?.Account;
        }


        public bool Transfer(int fromAccountId, int toAccountId, decimal sum)
        {
            var accountFrom = GetAccount(fromAccountId);
            var accountTo = GetAccount(toAccountId);

            if (accountTo == null || accountFrom == null) return false;

            if (accountFrom.Balance < sum) return false;

            accountFrom.Balance -= sum;
            accountTo.Balance += sum;
            return true;
        }

        public TransactionViewModel Withdraw(TransactionViewModel model)
        {
            model.AmountValid = false;
            model.AccountExist = false;
            if (CustomerAccountsViewModel.CustomerList.Exists(m => m.Account.AccountID == model.AccountNumber))
            {
                model.AccountExist = true;
                if (model.Amount > ((decimal)0.01))
                {
                    model.AmountValid = true;
                    var accounts = CustomerAccountsViewModel.CustomerList.Select(c => c.Account.AccountID);
                    if (accounts.Contains(model.AccountNumber))
                    {
                        var account =
                            CustomerAccountsViewModel.CustomerList.SingleOrDefault(m =>
                                m.Account.AccountID == model.AccountNumber);
                        if (model.Amount > account.Account.Balance)
                        {
                            model.AmountValid = false;
                            return model;
                        }

                        var amount = Math.Round(model.Amount, 2);
                        account.Account.Balance = (account.Account.Balance - amount);
                        return model;
                    }
                    else return null;

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

    }
}
