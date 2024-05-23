using System;
using Group5_LonghornAirlines_FinalProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Group5_LonghornAirlines_FinalProject.Models
{
    public enum Seat
    {
        A1, A2, A3, A4, A5, B1, B2, B3, B4, B5, C3, C4, C5, D3, D4, D5
    }
    public enum DiscountType { Senior, Child, None}
    public enum TicketStatus { Active, Pending, Canceled }
    public enum SeatStatus{ FirstClass, Economy }
    public enum TicketPaymentType { Cash, Miles }

    public class Ticket
    {
        //------------------- Properties-----------------------------------------------------------------
        [Key]
        public Int32 TicketID { get; set; }

        // call it ticketholderid?
        public AppUser TicketHolder { get; set; }

        public Reservation Reservation { get; set; }

        public Flight Flight { get; set; }

        public TicketStatus TicketStatus { get; set; }

        public Decimal Price { get; set; }

        public DiscountType DiscountType { get; set; }

        public Boolean CheckIn {  get; set; }

        public DateTime TicketDate { get; set; }

        //is this supposed to relate to cancellations or firstclass/economy?
        //Make an enum for this status (name approportiately so not conflict with employee status)
        //Might want to write an if statement using the index of an enum (idex > 4 is economy)
        public Seat Seat { get; set; }

        public SeatStatus SeatStatus { get; set; }

        public Int32 MilesEarned { get; set; }

        public Decimal PriceInMiles { get; set; }

        public Decimal  ModificationFee { get; set; }

        public TicketPaymentType TicketPaymentType { get; set; }

        [NotMapped]
        public Boolean Upgraded { get; set; }

        //Put this calcuation in the controller
        //public void CalcAdjustedPrice()
        //{
        //    decimal adjustedPrice = FlightID.EconomyPrice;

        //    if (seat.ToString()[0] == 'A' || seat.ToString()[0] == 'B')
        //    {
        //        adjustedPrice *= 1.2m;
        //    }
        //    else
        //    {
        //        if (TicketHolderID != null)
        //        {
        //            if (TicketHolderID.Age >= 65)
        //            {
        //                adjustedPrice *= 0.9m;
        //                DiscountType = discountType.senior;
        //            }

        //            else if (TicketHolderID.Age <= 12)
        //            {
        //                adjustedPrice *= 0.85m;
        //                DiscountType = discountType.child;
        //            }
        //        }
        //    }

        //    Price = adjustedPrice;
        //}

        //public void CalcMilesEarned()
        //{
        //    MilesEarned = FlightID.RouteID.Distance;
        //}

    }

}




