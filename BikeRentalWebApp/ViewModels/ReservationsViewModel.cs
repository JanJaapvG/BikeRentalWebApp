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
    public class ReservationsViewModel
    {
        private readonly BikeRentalContext _db = new BikeRentalContext();

        public IEnumerable<Bike> Bikes { get; set; }
        public Reservation Reservation { get; set; }
        public Bike Bike { get; set; }
        public Store Store { get; set; }
        public SelectList Stores { get; set; }
        public SelectList Customers { get; set; }
        public Customer Customer { get; set; }
        public SelectList SelectedBike { get; set; }
        public SelectList SelectedStore { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }


        public ReservationsViewModel()
        {
            Bikes = _db.Bikes.Include(s => s.Store);
        }

        public ReservationsViewModel(int id) : this()
        {
            Bike = _db.Bikes.Find(id);
            Store = _db.Stores.Find(Bike.Store_Id);
            Stores = new SelectList(_db.Stores, "Id", "Name");
            SelectedBike = new SelectList(_db.Bikes, "Id", "Name", selectedValue: id);
            SelectedStore = new SelectList(_db.Stores, "Id", "Name", selectedValue: Store.Id );
            Customer = new Customer();
        }


        //public void Save()
        //{ 
        //    _db.Reservations.Add(Reservation);
        //    _db.SaveChanges();
        //}
    }
}
