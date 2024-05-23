
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


    public class SeedFlights
    {
        public static void SeedAllFlights(AppDbContext db)
        {
            List<Flight> AllFlights = new List<Flight>();


            Flight f1 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-04-15 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f1.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f1);



            Flight f2 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-04-16 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f2.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f2);



            Flight f3 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-04-17 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f3.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f3);



            Flight f4 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-04-18 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f4.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f4);



            Flight f5 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-04-19 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f5.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f5);



            Flight f6 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-04-22 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f6.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f6);



            Flight f7 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-04-23 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f7.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f7);



            Flight f8 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-04-24 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f8.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f8);



            Flight f9 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-04-25 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f9.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f9);



            Flight f10 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-04-26 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f10.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f10);



            Flight f11 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-04-29 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f11.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f11);



            Flight f12 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-04-30 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f12.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f12);



            Flight f13 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-01 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f13.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f13);



            Flight f14 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-02 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f14.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f14);



            Flight f15 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-03 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f15.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f15);



            Flight f16 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-06 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f16.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f16);



            Flight f17 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-07 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f17.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f17);



            Flight f18 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-08 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f18.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f18);



            Flight f19 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-09 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f19.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f19);



            Flight f20 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-10 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f20.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f20);



            Flight f21 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-13 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f21.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f21);



            Flight f22 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-14 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f22.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f22);



            Flight f23 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-15 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f23.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f23);



            Flight f24 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-16 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f24.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f24);



            Flight f25 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-17 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f25.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f25);



            Flight f26 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-20 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f26.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f26);



            Flight f27 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-21 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f27.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f27);



            Flight f28 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-22 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f28.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f28);



            Flight f29 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-23 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f29.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f29);



            Flight f30 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-24 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f30.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f30);



            Flight f31 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-27 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f31.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f31);



            Flight f32 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-28 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f32.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f32);



            Flight f33 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-29 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f33.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f33);



            Flight f34 = new Flight()
            {
                FlightNumber = 1000,
                DepartureTime = DateTime.Parse("2024-05-30 08:00:00"),
                EconomyPrice = 105m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f34.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.DFW);
            AllFlights.Add(f34);



            Flight f35 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-15 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f35.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f35);



            Flight f36 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-16 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f36.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f36);



            Flight f37 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-17 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f37.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f37);



            Flight f38 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-18 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f38.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f38);



            Flight f39 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-19 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f39.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f39);



            Flight f40 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-20 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f40.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f40);



            Flight f41 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-21 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f41.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f41);



            Flight f42 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-22 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f42.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f42);



            Flight f43 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-23 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f43.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f43);



            Flight f44 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-24 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f44.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f44);



            Flight f45 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-25 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f45.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f45);



            Flight f46 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-26 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f46.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f46);



            Flight f47 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-27 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f47.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f47);



            Flight f48 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-28 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f48.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f48);



            Flight f49 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-29 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f49.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f49);



            Flight f50 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-04-30 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f50.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f50);



            Flight f51 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-01 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f51.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f51);



            Flight f52 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-02 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f52.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f52);



            Flight f53 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-03 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f53.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f53);



            Flight f54 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-04 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f54.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f54);



            Flight f55 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-05 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f55.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f55);



            Flight f56 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-06 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f56.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f56);



            Flight f57 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-07 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f57.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f57);



            Flight f58 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-08 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f58.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f58);



            Flight f59 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-09 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f59.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f59);



            Flight f60 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-10 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f60.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f60);



            Flight f61 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-11 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f61.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f61);



            Flight f62 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-12 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f62.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f62);



            Flight f63 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-13 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f63.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f63);



            Flight f64 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-14 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f64.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f64);



            Flight f65 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-15 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f65.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f65);



            Flight f66 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-16 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f66.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f66);



            Flight f67 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-17 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f67.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f67);



            Flight f68 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-18 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f68.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f68);



            Flight f69 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-19 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f69.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f69);



            Flight f70 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-20 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f70.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f70);



            Flight f71 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-21 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f71.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f71);



            Flight f72 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-22 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f72.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f72);



            Flight f73 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-23 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f73.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f73);



            Flight f74 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-24 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f74.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f74);



            Flight f75 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-25 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f75.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f75);



            Flight f76 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-26 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f76.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f76);



            Flight f77 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-27 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f77.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f77);



            Flight f78 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-28 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f78.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f78);



            Flight f79 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-29 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f79.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f79);



            Flight f80 = new Flight()
            {
                FlightNumber = 1002,
                DepartureTime = DateTime.Parse("2024-05-30 11:15:00"),
                EconomyPrice = 130m,
                status = Status.OnTime,
                DepDays = DepDays.Daily,

            };
            f80.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.AUS && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f80);



            Flight f81 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-04-15 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f81.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f81);



            Flight f82 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-04-16 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f82.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f82);



            Flight f83 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-04-17 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f83.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f83);



            Flight f84 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-04-18 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f84.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f84);



            Flight f85 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-04-19 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f85.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f85);



            Flight f86 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-04-22 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f86.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f86);



            Flight f87 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-04-23 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f87.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f87);



            Flight f88 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-04-24 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f88.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f88);



            Flight f89 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-04-25 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f89.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f89);



            Flight f90 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-04-26 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f90.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f90);



            Flight f91 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-04-29 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f91.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f91);



            Flight f92 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-04-30 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f92.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f92);



            Flight f93 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-01 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f93.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f93);



            Flight f94 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-02 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f94.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f94);



            Flight f95 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-03 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f95.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f95);



            Flight f96 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-06 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f96.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f96);



            Flight f97 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-07 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f97.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f97);



            Flight f98 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-08 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f98.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f98);



            Flight f99 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-09 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f99.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f99);



            Flight f100 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-10 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f100.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f100);



            Flight f101 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-13 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f101.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f101);



            Flight f102 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-14 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f102.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f102);



            Flight f103 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-15 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f103.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f103);



            Flight f104 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-16 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f104.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f104);



            Flight f105 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-17 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f105.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f105);



            Flight f106 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-20 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f106.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f106);



            Flight f107 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-21 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f107.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f107);



            Flight f108 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-22 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f108.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f108);



            Flight f109 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-23 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f109.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f109);



            Flight f110 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-24 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f110.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f110);



            Flight f111 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-27 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f111.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f111);



            Flight f112 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-28 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f112.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f112);



            Flight f113 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-29 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f113.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f113);



            Flight f114 = new Flight()
            {
                FlightNumber = 1006,
                DepartureTime = DateTime.Parse("2024-05-30 09:00:00"),
                EconomyPrice = 98m,
                status = Status.OnTime,
                DepDays = DepDays.Weekdays,

            };
            f114.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.ELP);
            AllFlights.Add(f114);



            Flight f115 = new Flight()
            {
                FlightNumber = 1014,
                DepartureTime = DateTime.Parse("2024-04-20 10:30:00"),
                EconomyPrice = 225m,
                status = Status.OnTime,
                DepDays = DepDays.Saturday,

            };
            f115.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f115);



            Flight f116 = new Flight()
            {
                FlightNumber = 1014,
                DepartureTime = DateTime.Parse("2024-04-27 10:30:00"),
                EconomyPrice = 225m,
                status = Status.OnTime,
                DepDays = DepDays.Saturday,

            };
            f116.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f116);



            Flight f117 = new Flight()
            {
                FlightNumber = 1014,
                DepartureTime = DateTime.Parse("2024-05-04 10:30:00"),
                EconomyPrice = 225m,
                status = Status.OnTime,
                DepDays = DepDays.Saturday,

            };
            f117.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f117);



            Flight f118 = new Flight()
            {
                FlightNumber = 1014,
                DepartureTime = DateTime.Parse("2024-05-11 10:30:00"),
                EconomyPrice = 225m,
                status = Status.OnTime,
                DepDays = DepDays.Saturday,

            };
            f118.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f118);



            Flight f119 = new Flight()
            {
                FlightNumber = 1014,
                DepartureTime = DateTime.Parse("2024-05-18 10:30:00"),
                EconomyPrice = 225m,
                status = Status.OnTime,
                DepDays = DepDays.Saturday,

            };
            f119.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f119);



            Flight f120 = new Flight()
            {
                FlightNumber = 1014,
                DepartureTime = DateTime.Parse("2024-05-25 10:30:00"),
                EconomyPrice = 225m,
                status = Status.OnTime,
                DepDays = DepDays.Saturday,

            };
            f120.FlightPath = db.FlightPaths.FirstOrDefault(fp => fp.DepartureCity == City.DFW && fp.ArrivalCity == City.HOU);
            AllFlights.Add(f120);


            foreach (Flight flightToAdd in AllFlights)
            {
                db.Flights.Add(flightToAdd);
                db.SaveChanges();
            }
        }
    }
}

