using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMBank.Models.Entities;

namespace ALMBank.Models.ViewModels
{
    public class TransactionViewModel
    {
        public Transaction Transaction { get; set; }
        public decimal Amount { get; set; }
        public int AccountNumber { get; set; }
        public bool AmountValid { get; set; }
        public bool AccountExist { get; set; }
    }
}
