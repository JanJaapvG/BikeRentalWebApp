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
        private readonly BikeRentalContext db = new BikeRentalContext();

        // GET: Reservations
        public ActionResult Index(string sortOrder)
        {
            return View(new ReservationsViewModel((string)sortOrder));
        }


        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create/
        public ActionResult Create(int? id)
        {
            return View(new ReservationsViewModel((int)id));
        }

        // POST: Reservations/Create
        [HttpPost]
        public ActionResult Create(ReservationsViewModel vm)
        {
            Customer existingCustomer = db.Customers.Where(e => e.Email == vm.Customer.Email).FirstOrDefault();
            if (existingCustomer == null)
            {
                vm.Customer.Store_Id = vm.SelectedStore.Id;
                db.Customers.Add(vm.Customer);
                db.SaveChanges();

                db.Customers.Find(vm.Customer.Id);

                vm.Reservation.Customer = vm.Customer;
                vm.Reservation.Customer_Id = vm.Customer.Id;
                vm.Reservation.Bike_Id = vm.SelectedBike.Id;
                vm.Reservation.PickupStore_Id = vm.SelectedStore.Id;

                db.Reservations.Add(vm.Reservation);
                db.SaveChanges();
            }
            else
            {
                vm.Customer = existingCustomer;
                vm.Reservation.Customer = vm.Customer;
                vm.Reservation.Customer_Id = vm.Customer.Id;
                vm.Reservation.Bike_Id = vm.SelectedBike.Id;
                vm.Reservation.PickupStore_Id = vm.SelectedStore.Id;

                db.Reservations.Add(vm.Reservation);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //POST: Reservations/Create
        //[HttpPost]
        //public ActionResult Create(ReservationsViewModel vm)
        //{
        //    vm.Save();
        //    return RedirectToAction("Index");
        //}
    }
}
