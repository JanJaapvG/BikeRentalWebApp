using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRental.Model
{
    public enum Category
    {
        Mountainbike,
        Racefiets,
        Stadsfiets,
        Elektrischefiets
    }

    public enum BikeSize
    { 
        Small,
        Medium,
        Large,
        ExtraLarge
    }

    public class Bike
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Fietsnaam")]
        [StringLength(100)]
        public string Name { get; set; }

        [DisplayName("Fiets omschrijving")]
        [StringLength(600)]
        public string Description { get; set; }

        [DisplayName("Fiets merk")]
        [StringLength(100)]
        public string Brand { get; set; }

        [Required]
        [DisplayName("Prijs per uur")]
        [Range(0, 100)]
        public double HourRate { get; set; }

        [Required]
        [DisplayName("Prijs per dag")]
        [Range(0, 100)]
        public double DailyRate { get; set; }

        public Category Type { get; set; }

        [Required]
        [DisplayName("Gender")]
        public Gender Gender { get; set; }

        [Required]
        [DisplayName("Fiets grootte")]
        public BikeSize BikeSize { get; set; }

        [ForeignKey("Store")]
        public int Store_Id { get; set; }
        public Store Store { get; set; }
    }
}
