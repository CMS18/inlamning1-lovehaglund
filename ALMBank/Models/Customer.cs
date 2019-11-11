using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMBank.Models
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public Account Account { get; set; }
    }
}
