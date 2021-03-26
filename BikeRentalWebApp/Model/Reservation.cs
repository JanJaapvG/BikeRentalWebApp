using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRental.Model
{
    public class Reservation
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        [ForeignKey("Bike")]
        public int Bike_Id { get; set; }
        public Bike Bike { get; set; }

        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Store")]
        public int Store_Id { get; set; }
        public Store Store { get; set; }

        [ForeignKey("DropoffStore")]
        public int DropoffStore_Id { get; set; }
        public Store DropoffStore { get; set; }

        [ForeignKey("PickupStore")]
        public int PickupStore_Id { get; set; }
        public Store PickupStore { get; set; }



    }
}
