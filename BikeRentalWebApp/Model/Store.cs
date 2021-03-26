using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRental.Model
{
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public int MaxCapacity { get; set; }

        public ICollection<Bike> Bikes { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public Store()
        {
            Bikes = new Collection<Bike>();
            Customers = new Collection<Customer>();
            Reservations = new Collection<Reservation>();
        }
    }
}
