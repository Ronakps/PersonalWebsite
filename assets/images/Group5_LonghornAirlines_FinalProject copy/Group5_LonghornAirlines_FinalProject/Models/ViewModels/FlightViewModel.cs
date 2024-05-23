using System;
using System.ComponentModel.DataAnnotations;



namespace Group5_LonghornAirlines_FinalProject.Models
{
    public enum PriceCriteria { GreaterThan, LessThan }

    public class FlightViewModel
    {
        [Display(Name = "Departure Time")]
        [DataType(DataType.Date)]
        public DateTime? DepartureTime { get; set; }
        
	    [Display(Name = "Arrival Time")]
        [DataType(DataType.Date)]
        public DateTime? ArrivalTime { get; set; }

        [Display(Name = "Departure City")]
        public City? DepartureCity { get; set; }

        [Display(Name = "Arrival City")]
        public City? ArrivalCity { get; set; }

        [Display(Name = "Economy Price per seat")]
        public decimal? Price { get; set; }

        [Display(Name = "Price Criteria:")]
        public PriceCriteria? PriceCriteria { get; set; }

        [Display(Name = "Select a flight number:")]
        public Int32? SelectedFlightNumber { get; set; }

        [Display(Name = "Minimum Availible Seats:")]
        public Int32? MinSeatCap { get; set; }
    }
}

