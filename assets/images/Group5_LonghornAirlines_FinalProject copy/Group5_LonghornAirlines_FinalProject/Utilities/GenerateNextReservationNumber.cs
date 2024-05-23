using Group5_LonghornAirlines_FinalProject.DAL;
using System;
using System.Linq;


namespace Group5_LonghornAirlines_FinalProject.Utilities
{
    public static class GenerateNextReservationNumber
    {
        public static Int32 GetNextReservationNumber(AppDbContext _context)
        {
            //set a constant to designate where the registration numbers
            //should start
            const Int32 START_NUMBER = 1000;

            Int32 intMaxReservationNumber; //the current maximum course number
            Int32 intNextReservationNumber; //the course number for the next class

            if (_context.Reservations.Count() == 0) //there are no registrations in the database yet
            {
                intMaxReservationNumber = START_NUMBER; //registration numbers start at 10001
            }
            else
            {
                intMaxReservationNumber = _context.Reservations.Max(c => c.ReservationNumber); //this is the highest number in the database right now
            }

            //You added records to the datbase before you realized
            //that you needed this and now you have numbers less than 100
            //in the database
            if (intMaxReservationNumber < START_NUMBER)
            {
                intMaxReservationNumber = START_NUMBER;
            }

            //add one to the current max to find the next one
            intNextReservationNumber = intMaxReservationNumber + 1;

            //return the value
            return intNextReservationNumber;
        }

    }
}
