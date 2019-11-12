using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMBank.Models.Entities
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public int ToAccount { get; set; }
        public int FromAccount { get; set; }
    }
}
