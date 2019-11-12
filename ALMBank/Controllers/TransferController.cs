using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMBank.Models.Services.Interface;
using ALMBank.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ALMBank.Controllers
{
    public class TransferController : Controller
    {
        private readonly IBank _bank;

        public TransferController(IBank bank)
        {
            _bank = bank;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TransferDto model)
        {
            if (ModelState.IsValid)
            {
                var success = _bank.Transfer(model.FromAccountId, model.ToAccountId, model.Sum);
                if (success)
                {
                    TempData["Message"] =
                        $"Successfully transferred {model.Sum:C} from account #{model.FromAccountId} to #{model.ToAccountId}";
                    return RedirectToAction(nameof(Index));
                }
                TempData["Error"] = $"Insufficient funds for the transfer.";
            }
            else
            {
                TempData["Error"] =
                    $"An error occured while making the transfer. Make sure the account number and amount is correct.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}