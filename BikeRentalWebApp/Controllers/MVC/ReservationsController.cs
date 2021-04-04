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
        private BikeRentalContext db = new BikeRentalContext();

        // GET: Reservations
        public ActionResult Index()
        {
            return View(new ReservationsViewModel());
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
        public ActionResult Create(Reservation reservation)
        {
            db.Reservations.Add(reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST: Reservations/Create
        //[HttpPost]
        // public ActionResult Create(ReservationsViewModel vm)
        // {
        //     vm.Save();
        //     return RedirectToAction("Index");
        // }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.Bike_Id = new SelectList(db.Bikes, "Id", "Name", reservation.Bike_Id);
            ViewBag.Customer_Id = new SelectList(db.Customers, "Id", "FirstName", reservation.Customer_Id);
            ViewBag.DropoffStore_Id = new SelectList(db.Stores, "Id", "Name", reservation.DropoffStore_Id);
            ViewBag.PickupStore_Id = new SelectList(db.Stores, "Id", "Name", reservation.PickupStore_Id);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Start,End,Bike_Id,Customer_Id,DropoffStore_Id,PickupStore_Id")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bike_Id = new SelectList(db.Bikes, "Id", "Name", reservation.Bike_Id);
            ViewBag.Customer_Id = new SelectList(db.Customers, "Id", "FirstName", reservation.Customer_Id);
            ViewBag.DropoffStore_Id = new SelectList(db.Stores, "Id", "Name", reservation.DropoffStore_Id);
            ViewBag.PickupStore_Id = new SelectList(db.Stores, "Id", "Name", reservation.PickupStore_Id);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
