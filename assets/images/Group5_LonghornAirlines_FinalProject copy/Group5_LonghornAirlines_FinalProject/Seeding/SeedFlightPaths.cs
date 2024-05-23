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
    public static class SeedFlightPaths
    {
        public static void SeedAllFlightPaths(AppDbContext db)
        {
            List<FlightPath> AllFlightPaths = new List<FlightPath>();

            AllFlightPaths.Add(new FlightPath()
            {
                FlightPathName = "AUS - DFW",
                DepartureCity = City.AUS,
                ArrivalCity = City.DFW,
                Distance = 190,
                Duration = new TimeSpan(0, 55, 0)

            });

            AllFlightPaths.Add(new FlightPath()
            {
                FlightPathName = "AUS - HOU",
                DepartureCity = City.AUS,
                ArrivalCity = City.HOU,
                Distance = 148,
                Duration = new TimeSpan(1, 0, 0)

            });

            AllFlightPaths.Add(new FlightPath()
            {
                FlightPathName = "AUS - ELP",
                DepartureCity = City.AUS,
                ArrivalCity = City.ELP,
                Distance = 527,
                Duration = new TimeSpan(1, 40, 0)

            });

            AllFlightPaths.Add(new FlightPath()
            {
                FlightPathName = "DFW - HOU",
                DepartureCity = City.DFW,
                ArrivalCity = City.HOU,
                Distance = 224,
                Duration = new TimeSpan(1, 13, 0)

            });

            AllFlightPaths.Add(new FlightPath()
            {
                FlightPathName = "DFW - ELP",
                DepartureCity = City.DFW,
                ArrivalCity = City.ELP,
                Distance = 551,
                Duration = new TimeSpan(1, 53, 0)

            });

            AllFlightPaths.Add(new FlightPath()
            {
                FlightPathName = "HOU - ELP",
                DepartureCity = City.HOU,
                ArrivalCity = City.ELP,
                Distance = 667,
                Duration = new TimeSpan(2, 9, 0)

            });

            AllFlightPaths.Add(new FlightPath()
            {
                FlightPathName = "DFW - AUS",
                DepartureCity = City.DFW,
                ArrivalCity = City.AUS,
                Distance = 190,
                Duration = new TimeSpan(0, 55, 0)

            });

            AllFlightPaths.Add(new FlightPath()
            {
                FlightPathName = "HOU - AUS",
                DepartureCity = City.HOU,
                ArrivalCity = City.AUS,
                Distance = 148,
                Duration = new TimeSpan(1, 0, 0)

            });

            AllFlightPaths.Add(new FlightPath()
            {
                FlightPathName = "ELP - AUS",
                DepartureCity = City.ELP,
                ArrivalCity = City.AUS,
                Distance = 527,
                Duration = new TimeSpan(1, 40, 0)

            });

            AllFlightPaths.Add(new FlightPath()
            {
                FlightPathName = "HOU - DFW",
                DepartureCity = City.HOU,
                ArrivalCity = City.DFW,
                Distance = 224,
                Duration = new TimeSpan(1, 13, 0)

            });

            AllFlightPaths.Add(new FlightPath()
            {
                FlightPathName = "ELP - DFW",
                DepartureCity = City.ELP,
                ArrivalCity = City.DFW,
                Distance = 551,
                Duration = new TimeSpan(1, 53, 0)

            });

            AllFlightPaths.Add(new FlightPath()
            {
                FlightPathName = "ELP - HOU",
                DepartureCity = City.ELP,
                ArrivalCity = City.HOU,
                Distance = 667,
                Duration = new TimeSpan(2, 9, 0)

            });

            foreach (FlightPath PathtoAdd in AllFlightPaths)
            {
                db.FlightPaths.Add(PathtoAdd);
                db.SaveChanges();
            }

        }

    }
}


