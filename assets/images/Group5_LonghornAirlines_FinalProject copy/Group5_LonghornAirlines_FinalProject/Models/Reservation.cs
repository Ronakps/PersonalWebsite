using Group5_LonghornAirlines_FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Make this namespace match your project name
namespace Group5_LonghornAirlines_FinalProject.Models
{
    public enum PaymentType { Cash, Miles }
    public enum ReservationStatus { Pending, Completed, Canceled }
    public class Reservation
    {

        private const Decimal TAX_RATE = 0.0825m;
        //-----------------Properties ---------------------------------------------------

        //Primary key
        [Key]
        [Display(Name = "Reservation ID")]
        public Int32 ReservationID { get; set; }

        [Display(Name = "Reservation Number")]
        [Range(1000, 9999, ErrorMessage = "The number must be four digits (1000-9999).")]
        public Int32 ReservationNumber { get; set; }

        //Enum to determine if payment is cash or miles
        [Display(Name = "Payment Type")]
        public PaymentType PaymentType { get; set; }

        public ReservationStatus ReservationStatus { get; set; }

        //public Decimal Subtotal
        //{
        //    get { return Tickets.Sum(t => t.Price); }
        //}

        //public decimal Subtotal
        //{
        //    get { return Tickets.Where(t => t.TicketStatus == TicketStatus.Active).Sum(t => t.Price); }
        //}

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Subtotal
        {
            get
            {
                return Tickets
                    .Where(t => t.TicketStatus == TicketStatus.Active)
                    .Sum(t => t.Price + t.ModificationFee);
            }
        }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Tax
        {
            get { return Subtotal * TAX_RATE; }

        }
        
	    [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Total
        {
            get { return Subtotal + Tax; }
        }

        [DisplayFormat(DataFormatString = "{0:0}")]
        public Decimal PriceInMilesTotal
        {
            get { return Tickets.Where(t => t.TicketStatus == TicketStatus.Active).Sum(t => t.PriceInMiles); }

        }

        [DisplayFormat(DataFormatString = "{0:0}")]
        [Display(Name = "Miles Deduction")]
        public Int32 MilesDeduction { get; set; }

        //-----------------Navigational Properties ---------------------------------------------------
        // Navigation property to tie back to the AppUser ID

        [Display(Name = "User ID")]
        public AppUser User { get; set; }

        // Navigation property for tickets - A single
        public List<Ticket> Tickets { get; set; }

        [NotMapped]
        public Int32? RequestedFlightNum { get; set; }

        //Creating a new list for Tickets if there isn't an existing list 
        public Reservation()
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
        }

        //-----------------Methods--------------------------------------------------------------

        //public void CalculateSubtotal()
        //{
        //    if (PaymentType == PaymentType.Cash)
        //    {
        //        Subtotal = 0;
        //        foreach (var ticket in Tickets)
        //        {
        //            Subtotal += ticket.Price;
        //        }
        //    }
        //}


        //public void CalculateTax()
        //{
        //    Tax = 0.0825M * Subtotal;
        //}


        //public void CalculateTotal()
        //{
        //    // Calculate total by adding the subtotal and the tax amount
        //    Total = Subtotal + Tax;
        //}


        public void CalculateMilesDeduction()
        {
            MilesDeduction = 0;
            if (PaymentType == PaymentType.Miles)
            {
                foreach (var ticket in Tickets)
                {
                    // Check if the ticket is first class or not
                    if (ticket.Seat.ToString()[0] == 'A' || ticket.Seat.ToString()[0] == 'B')
                    {
                        MilesDeduction += 2000; // Deduct 2000 miles for first class ticket
                    }
                    else
                    {
                        MilesDeduction += 1000; // Deduct 1000 miles for economy ticket
                    }
                }
            }
        }


        public void AddMiles()
        {
            if (PaymentType == PaymentType.Cash)
                foreach (var ticket in Tickets)
                    ticket.TicketHolder.Miles += ticket.MilesEarned;
        }


        public void ExpenseMiles()
        {
            if (PaymentType == PaymentType.Miles)
                User.Miles -= MilesDeduction;
        }
    }
}