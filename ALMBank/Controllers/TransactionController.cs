using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMBank.Models.Services.Interface;
using ALMBank.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALMBank.Controllers
{
    public class TransactionController : Controller
    {
        private IBank _bank;
        public TransactionController(IBank bank)
        {
            _bank = bank;
        }
        public IActionResult Index()
        {
            TransactionViewModel model = new TransactionViewModel();
            
            return View(model);
        }
        [HttpPost]
        public IActionResult Withdraw(TransactionViewModel model)
        {
            if (model.Amount > ((decimal) 0.01))
            {
                if (CustomerAccountsViewModel.CustomerList.Exists(m => m.Account.AccountID == model.AccountNumber))
                {
                    model = _bank.Withdraw(model);
                }
                else
                {
                    ModelState.AddModelError("", "Account does not exist");
                    return View("Index", model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid amount");
                return View("Index", model);

            }

            if (model.AmountValid == false)
            {
                ModelState.AddModelError("", "You dont have enough money");
                return View("Index",model);
            }

            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public IActionResult Deposit(TransactionViewModel model)
        {
            if (model.Amount > ((decimal)0.01))
            {
                if (CustomerAccountsViewModel.CustomerList.Exists(m => m.Account.AccountID == model.AccountNumber))
                {
                    model = _bank.Deposit(model);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Account does not exist");
                    return View("Index", model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid amount");
                return View("Index", model);
            }
           
           
        }
    }
}
