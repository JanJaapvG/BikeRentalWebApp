using System;
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
        [DisplayName("Fiets")]
        public int Bike_Id { get; set; }
        public Bike Bike { get; set; }

        [Required]
        [ForeignKey("Customer")]
        [DisplayName("Klant e-mail adres")]
        public int Customer_Id { get; set; }
        public Customer Customer { get; set; }


        [Required]
        [ForeignKey("DropoffStore")]
        [DisplayName("Inlever winkel")]
        public int DropoffStore_Id { get; set; }
        public Store DropoffStore { get; set; }

        [Required]
        [ForeignKey("PickupStore")]
        [DisplayName("Afhaal winkel")]
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
