using BikeRental.Model;
using BikeRentalWebApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeRentalWebApp.ViewModels
{
    public class ReservationsCreateViewModel
    {
        private readonly BikeRentalContext _db = new BikeRentalContext();

        public Reservation Reservation { get; set; }
        public SelectList AllStores { get; set; }
        public SelectList AllBikes { get; set; }
        public SelectList AllCustomers { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }


        public ReservationsCreateViewModel()
        {
            AllStores = new SelectList(_db.Stores, "Id", "Name");
            AllBikes = new SelectList(_db.Bikes, "Id", "Name");
            AllCustomers = new SelectList(_db.Customers, "Id", "Email");
        }

        //public void Save()
        //{
        //    _db.Reservations.Add(Reservation);
        //    _db.SaveChanges();
        //}
    }
}
