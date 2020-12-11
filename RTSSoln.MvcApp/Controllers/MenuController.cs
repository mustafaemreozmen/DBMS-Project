using Microsoft.AspNetCore.Mvc;
using RTSSoln.Domain.Entities;
using RTSSoln.Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTSSoln.MvcApp.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            MenuHandler menuHandler = new MenuHandler();
            var data = menuHandler.Select();
            return View(data);
        }

        public IActionResult Delete(Guid menuId)
        {
            MenuHandler menuHandler = new MenuHandler();
            menuHandler.Delete(menuId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(Guid menuId)
        {
            MenuHandler menuHandler = new MenuHandler();
            var selectedItem = menuHandler.SelectOne(menuId);
            return View(selectedItem);
        }
        [HttpPost]
        public IActionResult Update(Menu menu)
        {
            MenuHandler menuHandler = new MenuHandler();
            menuHandler.Update(menu);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Menu menu)
        {
            MenuHandler menuHandler = new MenuHandler();
            menu.Id = Guid.NewGuid();
            menu.Created = DateTime.Now;
            menuHandler.Insert(menu);
            return RedirectToAction("Index");
        }
    }
}
