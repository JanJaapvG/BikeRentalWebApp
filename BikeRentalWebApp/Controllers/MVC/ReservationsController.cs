using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeRental.Model;
using BikeRentalWebApp.Model;
using BikeRentalWebApp.ViewModels;

namespace BikeRentalWebApp.Controllers.MVC
{
    public class ReservationsController : Controller
    {
        // GET: Reservations/
        public ActionResult Index(string sortOrder)
        {
            return View(new ReservationsViewModel((string)sortOrder));
        }


        // GET: Reservations/Create/5
        public ActionResult Create(int? id)
        {
            return View(new ReservationsViewModel((int)id));
        }

        //POST: Reservations/Create
        [HttpPost]
        public ActionResult Create(ReservationsViewModel vm)
        {
            vm.Save();
            var customerId = vm.Customer.Id;
            return RedirectToAction("Details", new { id = customerId });
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
