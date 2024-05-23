using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group5_LonghornAirlines_FinalProject.DAL;
using Group5_LonghornAirlines_FinalProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace Group5_LonghornAirlines_FinalProject.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ReportsController : Controller
	{
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        //public IActionResult Report(bool includeTotalSeatsSold = true, bool includeTotalRevenue = true)
        //{
        //    ViewBag.IncludeTotalSeatsSold = includeTotalSeatsSold;
        //    ViewBag.IncludeTotalRevenue = includeTotalRevenue;
        //    if (includeTotalSeatsSold)
        //    {
        //        int totalSeatsSold = _context.Tickets.Count();
        //        ViewBag.TotalSeatsSold = totalSeatsSold;
        //    }
        //    if (includeTotalRevenue)
        //    {
        //        decimal totalRevenue = _context.Tickets.Sum(t => t.Price);
        //        ViewBag.TotalRevenue = totalRevenue;
        //    }
        //    return View();
        //}

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            // LINQ query to retrieve flights from the database
            var query = from t in _context.Tickets
                        where t.TicketStatus == TicketStatus.Active
                        select t;

            var query2 = from t in _context.Tickets
                        where t.TicketStatus == TicketStatus.Canceled
                        select t;

            // Apply search filter if searchString is not null or empty
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    // Modify the query to filter by FlightNumber
            //    query = query.Where(t => f.FlightNumber.ToString().Contains(searchString));
            //}

            // Order the flights by FlightNumber
            //query = query.OrderBy(f => f.FlightNumber);

            // Execute the query
            var tickets = await query.ToListAsync();
            var tickets2 = await query2.ToListAsync();

            // Populate the ViewBag with a count of all Ticket
            //ViewBag.TotalTicketCount = _context.Tickets.Count();

            // Populate the ViewBag with a count of selected flights
            ViewBag.TotalTicketCount = tickets.Count;

            ViewBag.TotalRevenue = tickets.Sum(t => t.Price);

            ViewBag.TotalRevenue = ViewBag.TotalRevenue + tickets.Sum(t => t.ModificationFee);

            ViewBag.TotalRevenue = ViewBag.TotalRevenue + tickets2.Sum(t => t.ModificationFee);

            return View(tickets);
        }

        public IActionResult DetailedSearch()
        {
            return View("DetailedSearch");
        }

        [HttpPost]
        public IActionResult DisplaySearchResults(ReportsViewModel rvm)
        {
            var query = from t in _context.Tickets
                        select t;

            if (rvm.MinDate.HasValue) //user entered something
            {
                // Extract date part from the user input and compare with the date part of DepartureTime
                var departureDate = rvm.MinDate.Value.Date;
                query = query.Where(f => f.Flight.DepartureTime.Date >= departureDate);
            }

            if (rvm.MaxDate.HasValue) //user entered something
            {
                // Extract date part from the user input and compare with the date part of DepartureTime
                var departureDate = rvm.MaxDate.Value.Date;
                query = query.Where(f => f.Flight.DepartureTime.Date <= departureDate);
            }

            //For dep and arrival city
            if (rvm.DepartureCity != null) // User selected a specific format
            {
                query = query.Where(f => f.Flight.FlightPath.DepartureCity == rvm.DepartureCity);
            }

            if (rvm.ArrivalCity != null) // User selected a specific format
            {
                query = query.Where(f => f.Flight.FlightPath.ArrivalCity == rvm.ArrivalCity);
            }

            if (rvm.SeatStatus != null) // User selected a specific format
            {
                query = query.Where(f => f.SeatStatus == rvm.SeatStatus);
            }

            query = query.Where(t => t.TicketStatus == TicketStatus.Active);

            List<Ticket> SelectedTickets = query.ToList();

            var canceledTickets = from t in _context.Tickets
                                  where t.TicketStatus == TicketStatus.Canceled
                                  select t;

            List<Ticket> CanceledTickets = canceledTickets.ToList();

            var totalModificationFeeForCanceledTickets = canceledTickets.Sum(t => t.ModificationFee);

            // Adjust the modification fee for active tickets
            var totalModificationFeeForActiveTickets = SelectedTickets.Sum(t => t.ModificationFee);

            ViewBag.TotalRevenue = SelectedTickets.Sum(t => t.Price) + totalModificationFeeForActiveTickets + totalModificationFeeForCanceledTickets;

            ViewBag.TotalTicketCount = SelectedTickets.Count;
            // ViewBag.TotalRevenue = SelectedTickets.Sum(t => t.Price);


            return View("Index", SelectedTickets);
        }

        public async Task<IActionResult> FlightManifest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.FlightPath)
                .Include(t => t.Tickets)
                .ThenInclude(U => U.TicketHolder)
                .FirstOrDefaultAsync(m => m.FlightID == id);

            if (flight == null)
            {
                return NotFound();
            }

            if(flight.status == Status.Departed)
            {
                return View("DepartedFlightManifest", flight);
            } else if (flight.status == Status.OnTime)
            {
                return View("FutureFlightManifest", flight);
            }

            return View("Index", flight);
        }
    }
}

