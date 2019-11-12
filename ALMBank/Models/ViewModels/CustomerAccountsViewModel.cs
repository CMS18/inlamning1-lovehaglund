using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMBank.Models.ViewModels
{
    public static class CustomerAccountsViewModel
    {
        public static List<Customer> CustomerList { get; set; }

        static CustomerAccountsViewModel()
        {
            CustomerList = new List<Customer>();
        }

    }
}
