using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMBank.Models
{
    public class Account
    {
        public string AccountName { get; set; }
        public int AccountID { get; set; }
        public decimal Balance { get; set; }
    }
}
