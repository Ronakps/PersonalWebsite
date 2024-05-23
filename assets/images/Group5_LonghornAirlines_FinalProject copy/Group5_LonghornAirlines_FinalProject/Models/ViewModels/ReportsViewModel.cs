using System;
using System.ComponentModel.DataAnnotations;



namespace Group5_LonghornAirlines_FinalProject.Models
{

    public class ReportsViewModel
    {
        [Display(Name = "Min Date:")]
        [DataType(DataType.Date)]
        public DateTime? MinDate{ get; set; }

        [Display(Name = "Max Date:")]
        [DataType(DataType.Date)]
        public DateTime? MaxDate { get; set; }

        [Display(Name = "Departure City")]
        public City? DepartureCity { get; set; }

        [Display(Name = "Arrival City")]
        public City? ArrivalCity { get; set; }

        [Display(Name = "Seat Type:")]
        public SeatStatus? SeatStatus { get; set; }

    }
}

