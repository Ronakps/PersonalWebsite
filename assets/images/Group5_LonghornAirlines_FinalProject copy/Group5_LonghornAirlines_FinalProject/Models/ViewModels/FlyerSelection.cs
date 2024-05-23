using System;
namespace Group5_LonghornAirlines_FinalProject.Models
{
    public class FlyerSelection
	{
        public AppUser Customer { get; set; }

        public bool Flyer { get; set; }

        public Seat SelectedSeat { get; set; } // Add this property to store the selected seat

        public DiscountType DiscountType { get; set; } // Add this property to store the selected seat

        public Decimal TicketPrice { get; set; }    

    }
}

