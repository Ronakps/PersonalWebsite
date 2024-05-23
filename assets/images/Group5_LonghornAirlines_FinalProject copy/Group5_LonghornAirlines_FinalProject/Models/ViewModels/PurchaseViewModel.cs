using System;
using System.ComponentModel.DataAnnotations;
using Group5_LonghornAirlines_FinalProject.Models;

namespace Group5_LonghornAirlines_FinalProject.ViewModels
{
    public class PurchaseViewModel
    {
        public int FlightId { get; set; }

        [Required(ErrorMessage = "AdvantageNumber is required")]
        [Range(5000, int.MaxValue, ErrorMessage = "AdvantageNumber must be a number greater than 4999")]
        public int? AdvantageNumber { get; set; }

        [Display(Name = "Flight Number")]
        [Range(1, int.MaxValue, ErrorMessage = "The number must be greater than 0.")]
        public int FlightNumber { get; set; }

        [Display(Name = "Date and Time of Flight")]
        public DateTime DepartureTime { get; set; }

        [Display(Name = "Economy Price per seat")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal EconomyPrice { get; set; }

        public FlightPath FlightPath { get; set; }

        [Display(Name = "Status of Flight")]
        public Status status { get; set; }

        [Display(Name = "Dates of Departure: ")]
        public DepDays DepDays { get; set; }
    }
}
