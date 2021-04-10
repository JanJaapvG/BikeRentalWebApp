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
        public string SortOrder { get;  set; }

        public ReservationsViewModel()
        { 
            Bikes = _db.Bikes.Include(s => s.Store);


            var Bike = from b in _db.Bikes
                        select b;

            


            StoreSort = string.IsNullOrEmpty(SortOrder) ? "Store" : "";
            GenderSort = SortOrder == "Gender" ? "Gender_desc" : "Gender" ;
            TypeSort = SortOrder == "Type" ? "Type_desc" : "Type";

           

            switch (SortOrder)
            {
                case "Store_desc":
                    Bike = Bike.OrderByDescending(b => b.Store.Name);
                    break;
                case "Gender_desc":
                    Bike = Bike.OrderByDescending(b => b.Gender);
                    break;
                case "Gender":
                    Bike = Bike.OrderBy(b => b.Gender);
                    break;
                case "Type_desc":
                    Bike = Bike.OrderByDescending(b => b.Type);
                    break;
                case "Type":
                    Bike = Bike.OrderBy(b => b.Type);
                    break;

            }

           
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
