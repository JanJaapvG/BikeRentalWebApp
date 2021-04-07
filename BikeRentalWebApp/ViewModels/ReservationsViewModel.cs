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
        public Bike SelectedBike { get; set; }
        public Store SelectedStore { get; set; }
        public SelectList Stores { get; set; }
        public Customer Customer { get; set; }

        public ReservationsViewModel()
        {
            Bikes = _db.Bikes.Include(s => s.Store);
        }

        public ReservationsViewModel(int id) : this()
        {
            SelectedBike = _db.Bikes.Find(id);
            SelectedStore = _db.Stores.Find(SelectedBike.Store_Id);
            Stores = new SelectList(_db.Stores, "Id", "Name");
        }

        //public void Save()
        //{
        //    Customer existingCustomer = (Customer)_db.Customers.Where(e => e.Email == Customer.Email).FirstOrDefault();
        //    if (existingCustomer == null)
        //    {
        //        Customer.Store_Id = Reservation.PickupStore_Id;
        //        _db.Customers.Add(Customer);
        //        _db.SaveChanges();

        //        _db.Customers.Find(Customer.Id);

        //        Reservation.Customer = Customer;
        //        Reservation.Customer_Id = Customer.Id;

        //        _db.Reservations.Add(Reservation);
        //        _db.SaveChanges();
        //    }
        //    else
        //    {
        //        Customer = existingCustomer;
        //        Reservation.Customer = Customer;
        //        Reservation.Customer_Id = Customer.Id;

        //        _db.Reservations.Add(Reservation);
        //        _db.SaveChanges();
        //    }
        //}
    }
}
