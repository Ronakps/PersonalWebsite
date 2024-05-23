
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


    public class SeedReservations
    {
        public static void SeedAllReservations(AppDbContext db)
        {

            List<Reservation> AllReservations = new List<Reservation>();


            Reservation r1 = new Reservation()
            {
                ReservationNumber = 10000,
                PaymentType = PaymentType.Cash,
                MilesDeduction = 0,
                ReservationStatus = ReservationStatus.Completed
                //Subtotal = 117m,
                //Tax = 9.65m,
                //Total = 126.65m
            };
            r1.User = db.Users.FirstOrDefault(u => u.FirstName + " " + u.LastName == "Christopher Baker");
            AllReservations.Add(r1);



            Reservation r2 = new Reservation()
            {
                ReservationNumber = 10001,
                PaymentType = PaymentType.Cash,
                MilesDeduction = 0,
                ReservationStatus = ReservationStatus.Completed
                //Subtotal = 810m,
                //Tax = 66.83m,
                //Total = 876.83m
            };
            r2.User = db.Users.FirstOrDefault(u => u.FirstName + " " + u.LastName == "Wendy Chang");
            AllReservations.Add(r2);



            Reservation r3 = new Reservation()
            {
                ReservationNumber = 10002,
                PaymentType = PaymentType.Cash,
                MilesDeduction = 0,
                ReservationStatus = ReservationStatus.Completed
                //Subtotal = 98m,
                //Tax = 8.09m,
                //Total = 106.09m
            };
            r3.User = db.Users.FirstOrDefault(u => u.FirstName + " " + u.LastName == "Margaret Garcia");
            AllReservations.Add(r3);


            foreach (Reservation reservationToAdd in AllReservations)
            {
                db.Reservations.Add(reservationToAdd);
                db.SaveChanges();

            }
        }
    }
}

