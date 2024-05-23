using Group5_LonghornAirlines_FinalProject.Models;

namespace Group5_LonghornAirlines_FinalProject.ViewModels
{
    public class ProceedViewModel
    {
        public int FlightID { get; set; } // Added FlightID variable
        public Flight Flight { get; set; }
        public Ticket Ticket { get; set; }
        public string SelectedSeat { get; set; }
    }
}