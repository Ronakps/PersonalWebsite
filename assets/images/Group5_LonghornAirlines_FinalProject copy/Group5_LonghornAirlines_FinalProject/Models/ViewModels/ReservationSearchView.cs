using Group5_LonghornAirlines_FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Group5_LonghornAirlines_FinalProject.Models
{

    public enum BeforeAfter
    {
        Before,
        After
    }

    public class ReservationSearchView
    {
        // Reservation properties
        [Display(Name = "Reservation Number")]
        public Int32? ReservationNumber { get; set; }

        [Display(Name = "Payment Type")]
        public PaymentType? PaymentType { get; set; }

        [Display(Name = "Price Criteria:")]
        public PriceCriteria? PriceCriteria { get; set; }

        [Range(5000, int.MaxValue, ErrorMessage = "AdvantageNumber must be a number greater than 4999")]
        public Int32? AdvantageNumber { get; set; }

        public string? Email { get; set; }

            [Display(Name = "Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid price.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Total { get; set; }

        // Ticket properties
        [Display(Name = "Ticket ID")]
        public Int32? TicketID { get; set; }

        [Display(Name = "TicketHolder First Name")]
        public string? TicketholderFN { get; set; }

        [Display(Name = "TicketHolder Last Name")]
        public string? TicketholderLN { get; set; }

        // Flight properties
        [Display(Name = "Flight ID")]
        public Int32? FlightID { get; set; }

        [Display(Name = "Flight Number")]
        public Int32? FlightNumber { get; set; }

        [Display(Name = "Before or After")]
        public BeforeAfter? BeforeAfter { get; set; }

        [Display(Name = "Date and Time of Flight")]
        public DateTime? DepartureTime { get; set; }

        [Display(Name = "Departure City")]
        public City? DepartureCity { get; set; }

        [Display(Name = "Arrival City")]
        public City? ArrivalCity { get; set; }

    }
}












