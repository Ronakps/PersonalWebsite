using System;
using System.Collections.Generic; // Add this namespace for List<>
using System.ComponentModel.DataAnnotations;

namespace Group5_LonghornAirlines_FinalProject.Models
{
    public enum City { AUS, ELP, DFW, HOU }

public class FlightPath
    { 
        public Int32 FlightPathID { get; set; }

        [Display(Name = "Flight Path")]
        public String FlightPathName { get; set; }

        [Required]
        [Display(Name = "Departure City")]
        public City DepartureCity { get; set; }

        [Required]
        [Display(Name = "Arrival City")]
        public City ArrivalCity { get; set; }

        public Int32 Distance { get; set; }

        public TimeSpan Duration { get; set; }

        // Navigation property for flights - A single route can have multiple flights
        public List<Flight> Flights { get; set; }

        // Constructor to initialize the Flights list
        public FlightPath()
        {
            Flights = new List<Flight>();
        }
    }
}

