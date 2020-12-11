using Microsoft.AspNetCore.Mvc;
using RTSSoln.Domain.Entities;
using RTSSoln.Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTSSoln.MvcApp.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly OrderItemHandler _orderItemHandler;
        public OrderItemController()
        {
            _orderItemHandler = new OrderItemHandler();
        }
        public IActionResult Index()
        {
            var data = _orderItemHandler.Select();
            return View(data);
        }

        public IActionResult Delete(Guid orderItemId)
        {
            _orderItemHandler.Delete(orderItemId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(Guid orderItemId)
        {
            var selectedItem = _orderItemHandler.SelectOne(orderItemId);
            return View(selectedItem);
        }
        [HttpPost]
        public IActionResult Update(OrderItem orderItem)
        {
            _orderItemHandler.Update(orderItem);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(OrderItem orderItem)
        {
            orderItem.Id = Guid.NewGuid();
            orderItem.Created = DateTime.Now;
            _orderItemHandler.Insert(orderItem);
            return RedirectToAction("Index");
        }
    }
}
