using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRental.Model
{
    public class Store
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Winkelnaam")]
        [StringLength(100)]
        public string Name { get; set; }

        [DisplayName("Adres")]
        [StringLength(200)]
        public string Adress { get; set; }

        [DisplayName("Stad")]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [DisplayName("Maximale opslag")]
        [Range(0, 5)]
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
