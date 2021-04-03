﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRental.Model
{
    public class Reservation: IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Begintijd")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Start { get; set; }

        [Required]
        [DisplayName("Eindtijd")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime End { get; set; }

        [Required]
        [ForeignKey("Bike")]
        [DisplayName("Bike type")]
        public int Bike_Id { get; set; }
        public Bike Bike { get; set; }

        [Required]
        [ForeignKey("Customer")]
        [DisplayName("Klant e-mail adres")]
        public int Customer_Id { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Store")]
        public int Store_Id { get; set; }
        public Store Store { get; set; }

        [ForeignKey("DropoffStore")]
        [DisplayName("Dropoff winkel")]
        public int DropoffStore_Id { get; set; }
        public Store DropoffStore { get; set; }

        [Required]
        [ForeignKey("PickupStore")]
        [DisplayName("Afhaalwinkel")]
        public int PickupStore_Id { get; set; }
        public Store PickupStore { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (End < Start)
            {
                yield return new ValidationResult(
                    errorMessage: "Einddatum moet later zijn dan de begindatum",
                    memberNames: new[] { "End" }
               );
            }
        }
    }
}
