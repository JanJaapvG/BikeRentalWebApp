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
        public string StoreSort { get;  set; }
        public string GenderSort { get;  set; }
        public string TypeSort { get;  set; }

        public ReservationsViewModel()
        {

        }

        public ReservationsViewModel(string sortOrder)
        { 
            Bikes = _db.Bikes.Include(s => s.Store);

            StoreSort = String.IsNullOrEmpty(sortOrder) ? "Store_desc" : "";
            GenderSort = sortOrder == "Gender" ? "Gender_desc" : "Gender" ;
            TypeSort = sortOrder == "Type" ? "Type_desc" : "Type";


            switch (sortOrder)
            {
                case "Store_desc":
                    Bikes = Bikes.OrderByDescending(b => b.Store.Name);
                    break;
                case "Gender_desc":
                    Bikes = Bikes.OrderByDescending(b => b.Gender);
                    break;
                case "Gender":
                    Bikes = Bikes.OrderBy(b => b.Gender);
                    break;
                case "Type_desc":
                    Bikes = Bikes.OrderByDescending(b => b.Type);
                    break;
                case "Type":
                    Bikes = Bikes.OrderBy(b => b.Type);
                    break;
            }
        }

        public ReservationsViewModel(int id) : this()
        {
            SelectedBike = _db.Bikes.Find(id);
            SelectedStore = _db.Stores.Find(SelectedBike.Store_Id);
            Stores = new SelectList(_db.Stores, "Id", "Name");
        }

        public void Save()
        {
            Customer existingCustomer = _db.Customers.Where(e => e.Email == Customer.Email).FirstOrDefault();
            if (existingCustomer == null)
            {
                Customer.Store_Id = SelectedStore.Id;
                _db.Customers.Add(Customer);
                _db.SaveChanges();

                _db.Customers.Find(Customer.Id);

                Reservation.Customer = Customer;
                Reservation.Customer_Id = Customer.Id;
                Reservation.Bike_Id = SelectedBike.Id;
                Reservation.PickupStore_Id = SelectedStore.Id;
                Reservation.TotalPrice = ((Reservation.End - Reservation.Start).TotalDays * _db.Bikes.Find(SelectedBike.Id).DailyRate);

                _db.Reservations.Add(Reservation);
                _db.SaveChanges();
            }
            else
            {
                Customer = existingCustomer;
                Reservation.Customer = Customer;
                Reservation.Customer_Id = Customer.Id;
                Reservation.Bike_Id = SelectedBike.Id;
                Reservation.PickupStore_Id = SelectedStore.Id; 
                Reservation.TotalPrice = ((Reservation.End - Reservation.Start).TotalDays * _db.Bikes.Find(SelectedBike.Id).DailyRate);

                _db.Reservations.Add(Reservation);
                _db.SaveChanges();

            }
        }
    }
}
