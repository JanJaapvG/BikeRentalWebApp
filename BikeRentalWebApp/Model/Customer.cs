using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRental.Model
{

    public class Customer 
    {
        public int Id { get; set; }

        [DisplayName("Voornaam")]
        [Range(0, 100)]
        public string FirstName { get; set; }

        [DisplayName("Achternaam")]
        [Range(0, 100)]
        public string LastName { get; set; }

        [DisplayName("Geslacht")]
        public Gender Gender { get; set; }

        [Required]
        [DisplayName("E-mail")]
        [EmailAddress]
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
