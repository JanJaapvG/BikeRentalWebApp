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

        public SelectList AllStores { get; set; }

        public SelectList AllBikes { get; set; }
        public Reservation Reservations { get; set; }
        public Customer Customer { get; set; }

        public ReservationsCreateViewModel()
        {
            AllStores = new SelectList(_db.Stores, "Id", "Name");
            AllBikes = new SelectList(_db.Bikes, "Id", "Name");

        }
    }
}