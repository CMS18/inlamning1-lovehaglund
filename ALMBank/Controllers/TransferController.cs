using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMBank.Models.Services.Interface;
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
    }
}