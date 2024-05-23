
using Group5_LonghornAirlines_FinalProject.DAL;
using Group5_LonghornAirlines_FinalProject.Models;
using Group5_LonghornAirlines_FinalProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Group5_LonghornAirlines_FinalProject.Seeding
{


    public class SeedTickets
    {
      public static void SeedAllTickets(AppDbContext db)
      {

          List<Ticket> AllTickets = new List<Ticket>();


              Ticket t1 = new Ticket()
              {
                  Seat = Seat.A3,
                  Price = 117m,
                  MilesEarned = 148,
                  TicketStatus = TicketStatus.Active,
                  PriceInMiles = 0,
                  ModificationFee = 0,
                  DiscountType = DiscountType.None,
                  CheckIn = false,
                  TicketDate = DateTime.Parse("2024-04-15 11:15:00"),
                  TicketPaymentType = TicketPaymentType.Cash,
                  SeatStatus = SeatStatus.Economy
              };
              t1.TicketHolder = db.Users.FirstOrDefault(u => u.FirstName + " " + u.LastName  == "Christopher Baker");
              t1.Reservation = db.Reservations.FirstOrDefault(r => r.ReservationNumber == 10000);
              t1.Flight = db.Flights.FirstOrDefault(f => f.FlightNumber == 1002);
              AllTickets.Add(t1);

      

              Ticket t2 = new Ticket()
              {
                  Seat = Seat.A1,
                  Price = 270m,
                  MilesEarned = 224,
                  TicketStatus = TicketStatus.Active,
                  PriceInMiles = 0,
                  ModificationFee = 0,
                  DiscountType = DiscountType.None,
                  CheckIn = false,
                  TicketDate = DateTime.Parse("2024-04-20 10:30:00"),
                  TicketPaymentType = TicketPaymentType.Cash,
                  SeatStatus = SeatStatus.FirstClass
              };
              t2.TicketHolder = db.Users.FirstOrDefault(u => u.FirstName + " " + u.LastName  == "Wendy Chang");
              t2.Reservation = db.Reservations.FirstOrDefault(r => r.ReservationNumber == 10001);
              t2.Flight = db.Flights.FirstOrDefault(f => f.FlightNumber == 1014);
              AllTickets.Add(t2);

      

              Ticket t3 = new Ticket()
              {
                  Seat = Seat.B1,
                  Price = 270m,
                  MilesEarned = 224,
                  TicketStatus = TicketStatus.Active,
                  PriceInMiles = 0,
                  ModificationFee = 0,
                  DiscountType = DiscountType.None,
                  CheckIn = false,
                  TicketDate = DateTime.Parse("2024-04-20 10:30:00"),
                  TicketPaymentType = TicketPaymentType.Cash,
                  SeatStatus = SeatStatus.FirstClass
              };
              t3.TicketHolder = db.Users.FirstOrDefault(u => u.FirstName + " " + u.LastName  == "Lim Chou");
              t3.Reservation = db.Reservations.FirstOrDefault(r => r.ReservationNumber == 10001);
              t3.Flight = db.Flights.FirstOrDefault(f => f.FlightNumber == 1014);
              AllTickets.Add(t3);

      

              Ticket t4 = new Ticket()
              {
                  Seat = Seat.A2,
                  Price = 270m,
                  MilesEarned = 224,
                  TicketStatus = TicketStatus.Active,
                  PriceInMiles = 0,
                  ModificationFee = 0,
                  DiscountType = DiscountType.None,
                  CheckIn = false,
                  TicketDate = DateTime.Parse("2024-04-20 10:30:00"),
                  TicketPaymentType = TicketPaymentType.Cash,
                  SeatStatus = SeatStatus.FirstClass
              };
              t4.TicketHolder = db.Users.FirstOrDefault(u => u.FirstName + " " + u.LastName  == "Charles Haley");
              t4.Reservation = db.Reservations.FirstOrDefault(r => r.ReservationNumber == 10001);
              t4.Flight = db.Flights.FirstOrDefault(f => f.FlightNumber == 1014);
              AllTickets.Add(t4);

      

              Ticket t5 = new Ticket()
              {
                  Seat = Seat.B3,
                  Price = 98m,
                  MilesEarned = 551,
                  TicketStatus = TicketStatus.Active,
                  PriceInMiles = 0,
                  ModificationFee = 0,
                  DiscountType = DiscountType.None,
                  CheckIn = false,
                  TicketDate = DateTime.Parse("2024-04-16 09:00:00"),
                  TicketPaymentType = TicketPaymentType.Cash,
                  SeatStatus = SeatStatus.Economy
              };
              t5.TicketHolder = db.Users.FirstOrDefault(u => u.FirstName + " " + u.LastName  == "Margaret Garcia");
              t5.Reservation = db.Reservations.FirstOrDefault(r => r.ReservationNumber == 10002);
              t5.Flight = db.Flights.FirstOrDefault(f => f.FlightNumber == 1006);
              AllTickets.Add(t5);

      
          foreach (Ticket ticketToAdd in AllTickets)
          {
              db.Tickets.Add(ticketToAdd);
              db.SaveChanges();

        }
    }
}
}
