using System.ComponentModel;
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

        public string Name { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public double HourRate { get; set; }

        public double DailyRate { get; set; }

        public Category Type { get; set; }

        public Gender Gender { get; set; }

        public BikeSize BikeSize { get; set; }

        [ForeignKey("Store")]
        public int Store_Id { get; set; }
        public Store Store { get; set; }
    }
}
