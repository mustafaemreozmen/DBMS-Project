using Microsoft.AspNetCore.Mvc;
using RTSSoln.Domain.Entities;
using RTSSoln.Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTSSoln.MvcApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderHandler _orderHandler;
        public OrderController()
        {
            _orderHandler = new OrderHandler();
        }
        public IActionResult Index()
        {
            var data = _orderHandler.Select();
            return View(data);
        }

        public IActionResult Delete(Guid orderId)
        {
            _orderHandler.Delete(orderId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(Guid orderId)
        {
            var selectedItem = _orderHandler.SelectOne(orderId);
            return View(selectedItem);
        }
        [HttpPost]
        public IActionResult Update(Order order)
        {
            _orderHandler.Update(order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Order order)
        {
            order.Id = Guid.NewGuid();
            order.Created = DateTime.Now;
            _orderHandler.Insert(order);
            return RedirectToAction("Index");
        }
    }
}
