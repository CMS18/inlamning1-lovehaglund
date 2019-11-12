using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMBank.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Customer> Customers = new List<Customer>();
        public decimal TotalBalance { get; set; }
        public int NumberOfCustomers { get; set; }
    }
}
