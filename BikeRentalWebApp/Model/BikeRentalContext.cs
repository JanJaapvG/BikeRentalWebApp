using System;
using System.Data.Entity;
using System.Linq;

namespace BikeRentalWebApp.Model
{
    public class BikeRentalContext : DbContext
    {
        public BikeRentalContext() : base("name=BikeRentalContext")
        {

        }

        public System.Data.Entity.DbSet<BikeRental.Model.Store> Stores { get; set; }
        public System.Data.Entity.DbSet<BikeRental.Model.Bike> Bikes { get; set; }
        public System.Data.Entity.DbSet<BikeRental.Model.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<BikeRental.Model.Reservation> Reservations { get; set; }

    }
}