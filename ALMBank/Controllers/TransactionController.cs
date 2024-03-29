﻿using System;
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
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                    model = _bank.Withdraw(model);
                        if (model.AccountExist == false)
                        {
                            TempData["Error"] = "Account does not exist.";
                            return View("Index", model);
                        }
                        if (model.AmountValid == false)
                        {
                            TempData["Error"] = "Invalid amount";
                            return View("Index", model);

                        }
                        TempData["Message"] = $"Successfully withdrew {model.Amount:C} from account #{model.AccountNumber}";
            return View("Index");
            }
            else
            {
                TempData["Error"] = "An error occured while making the transfer. Make sure the account number(s) and amount is correctly formatted.";
                return View("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                model = _bank.Deposit(model);
                if (model.AccountExist == false)
                {
                    TempData["Error"] = "Account does not exist.";
                    return View("Index", model);
                }
                if (model.AmountValid == false)
                {
                    TempData["Error"] = "Invalid amount";
                    return View("Index", model);

                }
                TempData["Message"] = $"Successfully deposit {model.Amount:C} to account #{model.AccountNumber}";
                return View("Index");
            }
            else
            {
                TempData["Error"] = "An error occured while making the transfer. Make sure the account number(s) and amount is correctly formatted.";
                return View("Index");
            }

        }
    }
}
