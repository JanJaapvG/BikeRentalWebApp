using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRental.Model
{

    public class Customer 
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        [ForeignKey("Store")]
        public int Store_Id { get; set; }
        public Store Store { get; set; }

        //List with reservations of the customer itself.
        public ICollection<Reservation> Reservations { get; set; }

        public Customer()
        {
            Reservations = new Collection<Reservation>();
        }

    }

}
