using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTSSoln.MvcApp.Controllers
{
    public class CashRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
