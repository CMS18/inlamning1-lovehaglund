using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMBank.Models.ViewModels
{
    public class CustomerAccountsViewModel
    {
        public List<Customer> CustomerList { get; set; }

        public CustomerAccountsViewModel()
        {
            CustomerList = new List<Customer>();
        }
    }
}
