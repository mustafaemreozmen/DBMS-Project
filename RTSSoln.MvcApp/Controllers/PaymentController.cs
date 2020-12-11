using Microsoft.AspNetCore.Mvc;
using RTSSoln.Domain.Entities;
using RTSSoln.Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTSSoln.MvcApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PaymentHandler _paymentHandler;
        public PaymentController()
        {
            _paymentHandler = new PaymentHandler();
        }
        public IActionResult Index()
        {
            var data = _paymentHandler.Select();
            return View(data);
        }

        public IActionResult Delete(Guid paymentId)
        {
            _paymentHandler.Delete(paymentId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(Guid paymentId)
        {
            var selectedItem = _paymentHandler.SelectOne(paymentId);
            return View(selectedItem);
        }
        [HttpPost]
        public IActionResult Update(Payment payment)
        {
            _paymentHandler.Update(payment);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Payment payment)
        {
            payment.Id = Guid.NewGuid();
            payment.Created = DateTime.Now;
            _paymentHandler.Insert(payment);
            return RedirectToAction("Index");
        }
    }
}
