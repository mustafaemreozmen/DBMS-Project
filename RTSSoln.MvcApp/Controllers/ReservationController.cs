using Microsoft.AspNetCore.Mvc;
using RTSSoln.Domain.Entities;
using RTSSoln.Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTSSoln.MvcApp.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationHandler _reservationHandler;
        public ReservationController()
        {
            _reservationHandler = new ReservationHandler();
        }
        public IActionResult Index()
        {
            var data = _reservationHandler.Select();
            return View(data);
        }

        public IActionResult Delete(Guid reservationId)
        {
            _reservationHandler.Delete(reservationId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(Guid reservationId)
        {
            var selectedItem = _reservationHandler.SelectOne(reservationId);
            return View(selectedItem);
        }
        [HttpPost]
        public IActionResult Update(Reservation reservation)
        {
            _reservationHandler.Update(reservation);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Reservation reservation)
        {
            reservation.Id = Guid.NewGuid();
            reservation.Created = DateTime.Now;
            _reservationHandler.Insert(reservation);
            return RedirectToAction("Index");
        }
    }
}
