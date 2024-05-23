using System;
using System.ComponentModel.DataAnnotations;
namespace Group5_LonghornAirlines_FinalProject.Models

{
    
    public enum Status { Canceled, Delayed, OnTime, Departed }

    public enum DepDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, Weekdays, Weekends, Daily }

    public class Flight
    {
        [Key]
	    public Int32 FlightID { get; set; }

        [Display(Name = "Flight Number")]
        [Range(1000, 9999, ErrorMessage = "The number must be four digits (1000-9999).")]
        [Required]
        //[StringLength(4, MinimumLength = 4, ErrorMessage = "The number must be exactly 4 digits long.")]
        public Int32 FlightNumber { get; set; }

        [Required]
        [Display(Name = "Date and Time of Flight")]
        public DateTime DepartureTime { get; set; }

        //WOuldn't need this since the function is just returining
        //public DateTime ArrivalTime { get; set; }

        [Required]
        [Display(Name = "Economy Price per seat")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal EconomyPrice { get; set; }

        public FlightPath FlightPath { get; set; }

        [Required]
        [Display(Name = "Status of Flight")]
        public Status status { get; set; }

        //Days on which that flight departs 
        //Won't be seen by the customer - meant r management organization
        [Display(Name = "Dates of Departure: ")]
	    public DepDays DepDays { get; set; }

        // Navigation property for tickets - A single
        public List<Ticket> Tickets { get; set; }

        //Creating a new list for Tickets if there isn't an existing list 
        //public void TicketFlightID()
        //{
        //    Tickets ??= new List<Ticket>();
        //}

        public Flight()
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
        }

        public DateTime CalculateArrivalTime()
        {
            // Check if RouteID is not null and if the DepartureTime is set
            if (FlightPath != null && DepartureTime != null)
            {
                // Add the duration of the route to the departure time
                //Could redo this to return the value as the function is called; do line below instead of what is happening
                return DepartureTime.Add(FlightPath.Duration);
                
            }
            else
            {
                // If RouteID or DepartureTime is not set, return DateTime.MinValue
                return DateTime.MinValue;
            }

        }


    }
}


