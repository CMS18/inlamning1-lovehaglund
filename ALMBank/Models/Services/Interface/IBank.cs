using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMBank.Models.ViewModels;

namespace ALMBank.Models.Services.Interface
{
    public interface IBank
    {
        CustomerAccountsViewModel GetCustomer(CustomerAccountsViewModel model);

    }
}
