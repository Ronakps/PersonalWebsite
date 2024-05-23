using Group5_LonghornAirlines_FinalProject.DAL;
using System;
using System.Linq;

namespace Group5_LonghornAirlines_FinalProject.Utilities
{
    public static class GenerateNextReservationID
    {
        public static Int32 GetNextReservationNumber(AppDbContext _context)
        {
            // Set a constant to designate where the ReservationIDs should start
            const Int32 START_NUMBER = 10000;

            Int32 intNextReservationNumber; // The ReservationID for the next reservation

            // Get the maximum existing ReservationID from the database
            Int32? maxReservationNumber = _context.Reservations.Max(o => (Int32?)o.ReservationID);

            // Calculate the next ReservationID
            intNextReservationNumber = maxReservationNumber.HasValue ? maxReservationNumber.Value + 1 : START_NUMBER;

            return intNextReservationNumber;
        }
    }
}
