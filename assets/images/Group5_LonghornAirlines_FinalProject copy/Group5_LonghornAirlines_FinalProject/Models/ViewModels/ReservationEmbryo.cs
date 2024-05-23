using System;
using System.Collections.Generic;

namespace Group5_LonghornAirlines_FinalProject.Models
{
    public class ReservationEmbryo
    {
        public List<FlyerSelection> Flyers { get; set; }
        public Flight Flight { get; set; }

        public Decimal TotalReservationPrice { get; set; }

        public ReservationEmbryo()
        {
        }
    }
}
