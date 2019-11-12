using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitALMBank
{
    public class Exceptions
    {
        public class NotEnoughMoneyException : Exception
        {
            public NotEnoughMoneyException()
                : base("Not enough money.")
            {
            }
        }
    }
}
