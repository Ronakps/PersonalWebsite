using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group5_LonghornAirlines_FinalProject.DAL;
using Group5_LonghornAirlines_FinalProject.Models;
using Group5_LonghornAirlines_FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Group5_LonghornAirlines_FinalProject.Controllers
{
    [AllowAnonymous]
    public class FlightsController : Controller
    {
        private readonly AppDbContext _context;

        public FlightsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Flight
        public async Task<IActionResult> Index(string searchString, int? reservationID)
        {
            // LINQ query to retrieve flights from the database
            var query = from f in _context.Flights.Include(f => f.FlightPath)
                        select f;

            // Apply search filter if searchString is not null or empty
            if (!string.IsNullOrEmpty(searchString))
            {
                // Modify the query to filter by FlightNumber
                query = query.Where(f => f.FlightNumber.ToString().Contains(searchString));
            }

            // Order the flights by FlightNumber
            query = query.OrderBy(f => f.FlightNumber);

            // Execute the query
            var flights = await query.ToListAsync();

            // Populate the ViewBag with a count of all flights
            ViewBag.TotalFlightCount = _context.Flights.Count();

            // Populate the ViewBag with a count of selected flights
            ViewBag.SelectedFlightCount = flights.Count;

            // Check and update flight statuses
            //await UpdateFlightStatuses();

            return View(flights);
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                // User did not specify a FlightID – take them to the error view
                return View("Error", new string[] { "FlightID not specified - which flight do you want to view?" });
            }

            // Look up the flight in the database based on the id
            var flight = await _context.Flights
                .Include(f => f.Tickets)  // Make sure to include related Tickets data
                .FirstOrDefaultAsync(f => f.FlightID == id);

            if (flight == null)
            {
                // No flight with this id exists in the database – show the user an error view
                return View("Error", new string[] { "Flight not found in database" });
            }

            // If code gets this far, all is well – display the details
            return View(flight);
        }


        public IActionResult DetailedSearch()
        {
            return View("DetailedSearch");
        }

        [HttpPost]
        public IActionResult DisplaySearchResults(FlightViewModel fvm)
        {
            var query = from f in _context.Flights.Include(f => f.FlightPath) select f;
            if (fvm.DepartureTime.HasValue) //user entered something
            {
                // Extract date part from the user input and compare with the date part of DepartureTime
                var departureDate = fvm.DepartureTime.Value.Date;
                query = query.Where(f => f.DepartureTime.Date == departureDate);
            }
            if (fvm.ArrivalTime.HasValue) //user entered something
            {
                // Extract date part from the user input and compare with the date part of CalculateArrivalTime()
                var arrivalDate = fvm.ArrivalTime.Value.Date;
                query = query.Where(f => f.CalculateArrivalTime().Date == arrivalDate);
            }
            //For dep and arrival city
            if (fvm.DepartureCity != null) // User selected a specific format
            {
                query = query.Where(f => f.FlightPath.DepartureCity == fvm.DepartureCity);
            }
            if (fvm.ArrivalCity != null) // User selected a specific format
            {
                query = query.Where(f => f.FlightPath.ArrivalCity == fvm.ArrivalCity);
            }
            if (fvm.Price.HasValue)
            {
                if (fvm.PriceCriteria == PriceCriteria.GreaterThan)
                {
                    query = query.Where(f => f.EconomyPrice >= fvm.Price);
                }
                else if (fvm.PriceCriteria == PriceCriteria.LessThan)
                {
                    query = query.Where(f => f.EconomyPrice <= fvm.Price);
                }
                else
                {
                    // If neither GreaterThan nor LessThan is selected, perform exact search
                    query = query.Where(f => f.EconomyPrice == fvm.Price);
                }
            }

            //if (fvm.MinSeatCap.HasValue)
            //{
            //    //query = query.Where(f => Convert.ToInt32(f.CalculateAvailableSeats()) >= fvm.SeatCapacity);
            //    query = query.Where(f => f.CalculateAvailableSeats() >= fvm.MinSeatCap);
            //}

            List<Flight> SelectedFlights = query.ToList();

            if (fvm.MinSeatCap.HasValue)
            {
                for (int i = SelectedFlights.Count - 1; i >= 0; i--)
                {
                    var flight = SelectedFlights[i];
                    Int32 flightAvailableSeats = GetAvailableSeatsForFlight(flight.FlightID);
                    if (flightAvailableSeats < fvm.MinSeatCap)
                    {
                        SelectedFlights.RemoveAt(i);
                    }
                }
            }






            ViewBag.SelectedFlightCount = SelectedFlights.Count;
            ViewBag.TotalFlightCount = _context.Flights.Count();
            return View("Index", SelectedFlights);


        }




        public int GetAvailableSeatsForFlight(int flightId)
        {
            // Find the flight based on the flightId
            var flight = _context.Flights
                .Include(f => f.Tickets) // Include the Tickets navigation property
                .FirstOrDefault(f => f.FlightID == flightId);
            if (flight == null)
            {
                // Flight not found
                return -1; // Return an empty list
            }
            // Get all possible seats for the given flight’s aircraft
            var allSeats = Enum.GetValues(typeof(Seat)).Cast<Seat>().ToList(); // Assuming Seat is an enum
                                                                               // Get booked seats with an Active status for the given flight
            var activeBookedSeats = flight.Tickets
                                          .Where(t => t.TicketStatus == TicketStatus.Active)
                                          .Select(t => t.Seat)
                                          .ToList();
            // Find available seats by excluding actively booked seats
            var availableSeats = allSeats.Except(activeBookedSeats).ToList();
            return availableSeats.Count();
        }











        // GET: Flights/Create/5
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            if (User.IsInRole("Manager"))
            {
                ViewBag.AllFlightPaths = GetFlightPathSelectList();
                return View();
            }

            else
            {
                return View("Error");
            }
        }

        // POST: Flights/Create/5
        //THIS ONE IS GONNA BE FAT AS HELL
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create(FlightCreation flightCreation, int SelectedFlightPath)
        {
            ViewBag.AllFlightPaths = GetFlightPathSelectList(); // Prepopulate the flight paths for any return views

            if (!ModelState.IsValid)
            {
                return View("Create", flightCreation);
            }

            // Check if the flight number already exists in the database
            if (_context.Flights.Any(f => f.FlightNumber == flightCreation.FlightNumber))
            {
                ModelState.AddModelError("FlightNumber", "Flight number already exists.");
                return View("Create", flightCreation);
            }

            // Check if the departure time falls within a 15-minute interval
            if (flightCreation.DepartureTime.Minutes % 15 != 0)
            {
                ModelState.AddModelError("DepartureTime", "Please enter a departure time that falls within a 15-minute interval.");
                return View("Create", flightCreation);
            }
            var flightsToAdd = new List<Flight>();

            // Iterate over each day between start and end dates
            for (DateOnly currentDate = flightCreation.StartDate; currentDate <= flightCreation.EndDate; currentDate = currentDate.AddDays(1))
            {
                bool shouldCreateFlight = false;

                // Check if the current date falls within the selected DepDays
                switch (flightCreation.DepDays)
                {
                    case DepDays.Daily:
                        shouldCreateFlight = true;
                        break;
                    case DepDays.Weekdays:
                        shouldCreateFlight = currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday;
                        break;
                    case DepDays.Weekends:
                        shouldCreateFlight = currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday;
                        break;
                    default:
                        shouldCreateFlight = currentDate.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), flightCreation.DepDays.ToString());
                        break;
                }

                if (shouldCreateFlight)
                {
                    DateTime dateTime = currentDate.ToDateTime(new TimeOnly()); // Convert DateOnly to DateTime at midnight
                    dateTime = dateTime.Add(flightCreation.DepartureTime); // Add the TimeSpan to the DateTime

                    // Create a new flight instance
                    var newFlight = new Flight
                    {
                        FlightNumber = flightCreation.FlightNumber,
                        DepartureTime = dateTime, // Now you can assign it correctly
                        EconomyPrice = flightCreation.EconomyPrice,
                        FlightPath = _context.FlightPaths.Find(SelectedFlightPath),
                        status = Status.OnTime,
                        DepDays = flightCreation.DepDays
                    };

                    // Add the new flight to the list
                    flightsToAdd.Add(newFlight);
                }
            }

            if (flightsToAdd.Count > 0)
            {
                // Add all the flights to the context
                _context.AddRange(flightsToAdd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // No flights to add, possibly display a message or just reload the form
                ModelState.AddModelError("", "No flights were created based on the selected days and date range.");
                return View("Create", flightCreation);
            }
        }




            // GET: Flights/Edit/5
            [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {

            if (User.IsInRole("Manager"))
            {
                if (id == null)
                {
                    return NotFound();
                }

                Flight flight = await _context.Flights.FindAsync(id);
                if (flight == null)
                {
                    return NotFound();
                }
                return View(flight);
            }
            else
            {
                return View("Error");
            }

        }

        

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int id, Flight flight)
        {
            if (User.IsInRole("Manager"))
            {
                if (id != flight.FlightID)
                {
                    return NotFound();
                }

                if (flight.DepartureTime.Minute % 15 != 0)
                {
                    ModelState.AddModelError("DepartureTime", "Please enter a departure time that falls within a 15-minute interval.");
                    // Re-populate the ViewBag with flight paths and return to the create view
                    return View("Edit", flight);
                }

                Flight dbFlight = _context.Flights
                        .FirstOrDefault(f => f.FlightID == flight.FlightID);



                dbFlight.EconomyPrice = flight.EconomyPrice;
                dbFlight.DepartureTime = flight.DepartureTime;
                _context.Flights.Update(dbFlight);
                await _context.SaveChangesAsync();

                //if (ModelState.IsValid)
                //{
                //    try
                //    {
                //        Flight dbFlight = _context.Flights
                //        .FirstOrDefault(f => f.FlightID == flight.FlightID);

                //        dbFlight.EconomyPrice = flight.EconomyPrice;
                //        dbFlight.DepartureTime = flight.DepartureTime;
                //        _context.Update(flight);
                //        await _context.SaveChangesAsync();
                //    }
                //    catch (DbUpdateConcurrencyException)
                //    {
                //        if (!FlightExists(flight.FlightID))
                //        {
                //            return NotFound();
                //        }
                //        else
                //        {
                //            throw;
                //        }
                //    }
                //    return RedirectToAction(nameof(Index));
                //}
                //return View(flight);
                return RedirectToAction(nameof(Index));
            }

            else
            {
                return View("Error");
            }
        }

        // GET: Flights/Delete/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (User.IsInRole("Manager"))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var flight = await _context.Flights
                    .FirstOrDefaultAsync(m => m.FlightID == id);
                if (flight == null)
                {
                    return NotFound();
                }

                return View(flight);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (User.IsInRole("Manager"))
            {
                var flight = await _context.Flights
                    .Include(f => f.FlightPath)
                    .Include(f => f.Tickets)
                    .ThenInclude(t => t.TicketHolder)
                    .Include(f => f.Tickets)
                    .ThenInclude(t => t.Reservation)
                    .ThenInclude(r => r.User)
                    .FirstOrDefaultAsync(f => f.FlightID == id);

                if (flight != null)
                {
                    flight.status = Status.Canceled;
                    foreach (var ticket in flight.Tickets)
                    {
                        if (ticket.TicketStatus == TicketStatus.Active)
                        {
                            ticket.TicketStatus = TicketStatus.Canceled;
                            if (ticket.Reservation.PaymentType == PaymentType.Cash)
                            {
                                // For Cash payment, include a message about refund
                                ticket.TicketStatus = TicketStatus.Canceled;
                                ticket.Reservation.User.Miles += (int)ticket.PriceInMiles;
                                // Send email notification about refund
                                string cashRefundMessage = $"Hello {ticket.Reservation.User.FirstName} {ticket.Reservation.User.LastName},\n\nYour flight reservation (Paid in Cash) for Flight: {flight.FlightNumber} has been canceled for {flight.DepartureTime}. The ticket for {ticket.TicketHolder.FirstName} {ticket.TicketHolder.LastName} has been cancelled and you will receive your cash refund soon of $ {ticket.Price}.\n\n Please be sure to create your reservation again. When Longhorn Airlines is forced to cancel flights, customers are responsible for making a new reservation according to our policy. \n\n Thank you and fly again with us! ";
                                Utilities.EmailMessaging.SendEmail("Flight Cancellation - Cash Refund", cashRefundMessage, ticket.Reservation.User.Email);
                            }
                            else if (ticket.Reservation.PaymentType == PaymentType.Miles)
                            {
                                // For Miles payment, add the miles back to the customer's account
                                ticket.TicketStatus = TicketStatus.Canceled;
                                ticket.Reservation.User.Miles += (int)ticket.PriceInMiles;
                                // Send email notification about miles added back
                                string milesRefundMessage = $"Hello {ticket.Reservation.User.FirstName} {ticket.Reservation.User.LastName},\n\nYour flight reservation (Paid in Miles) for Flight: {flight.FlightNumber} has been canceled for {flight.DepartureTime}. The ticket for {ticket.TicketHolder.FirstName} {ticket.TicketHolder.LastName} has been cancelled and {ticket.PriceInMiles} miles have been added back to your account. \n\n Please be sure to create your reservation again. When Longhorn Airlines is forced to cancel flights, customers are responsible for making a new reservation according to our policy. \n\n Thank you and fly again with us! ";
                                Utilities.EmailMessaging.SendEmail("Flight Cancellation - Miles Refund", milesRefundMessage, ticket.Reservation.User.Email);
                            }
                        }

                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error");
            }
        }





        //----------------------------------
        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.FlightID == id);
        }

        //---------------------------------------------------------------
        [Authorize(Roles = "Manager")]
        public IActionResult Report()
        {
            return RedirectToAction("Index", "Reports");
	    }

        [Authorize(Roles = "Manager")]
        public IActionResult FlightManifest(int? id)
        {
            //var ReportController = new ReportsController(_context);

            //return ReportController.FlightManifest(id);

            return RedirectToAction("FlightManifest", "Reports", new { id = id });
        }

        [Authorize(Roles = "Manager,Agent")]
        public IActionResult ViewCustomers()
        {
            return RedirectToAction("Index", "AppUser");
        }


        //------------------------------------------------------------




        [HttpGet]
        public async Task<IActionResult> FlyerSelection(int? flightId)
        {
            if (flightId == null || !_context.Flights.Any(f => f.FlightID == flightId))
            {
                TempData["ErrorMessage"] = "Flight not found.";
                return RedirectToAction("Index");
            }

            var flight = _context.Flights.FirstOrDefault(f => f.FlightID == flightId);

            if (flight == null)
            {
                TempData["ErrorMessage"] = "Flight not found.";
                return RedirectToAction("Index");
            }

            var users = _context.Users.Where(u => u.AdvantageNumber != null).ToList();

            var flyers = new List<FlyerSelection>();

            foreach (var user in users)
            {
                // Determine discount type based on user's age
                DiscountType discountType = DiscountType.None;
                if (user.Age >= 65)
                {
                    discountType = DiscountType.Senior;
                }
                else if (user.Age <= 12)
                {
                    discountType = DiscountType.Child;
                }

                // Create FlyerSelection object for each user
                flyers.Add(new FlyerSelection
                {
                    Customer = user,
                    Flyer = false, // By default, no users are selected
                    DiscountType = discountType // Assign the determined discount type
                });
            }

            var reservationEmbryo = new ReservationEmbryo
            {
                Flight = flight,
                Flyers = flyers
            };

            ViewData["flightId"] = flightId;

            return View(reservationEmbryo);
        }

        [HttpPost]
        public async Task<IActionResult> FlyerSelection(List<string> selectedUserIds, Flight flight)
        {
            if (selectedUserIds == null || !selectedUserIds.Any() || flight == null)
            {
                TempData["ErrorMessage"] = "Please select at least one flyer.";
                return RedirectToAction("FlyerSelection", new { flight });
            }

            var existingFlight = await _context.Flights
                .Include(f => f.FlightPath)
                .Include(f => f.Tickets) // Include the Tickets navigation property
                .FirstOrDefaultAsync(m => m.FlightID == flight.FlightID);

            if (existingFlight == null)
            {
                TempData["ErrorMessage"] = "Flight details are not available.";
                return RedirectToAction("FlyerSelection", new { flight });
            }

            var selectedUsers = await _context.Users
                .Where(u => selectedUserIds.Contains(u.Id))
                .ToListAsync();

            if (selectedUsers.Count == 0)
            {
                TempData["ErrorMessage"] = "Selected users not found.";
                return RedirectToAction("FlyerSelection", new { flight });
            }

            var selectedFlyers = new List<FlyerSelection>();

            foreach (var selectedUser in selectedUsers)
            {
                // Determine discount type based on user's age
                DiscountType discountType = DiscountType.None;
                if (selectedUser.Age >= 65)
                {
                    discountType = DiscountType.Senior;
                }
                else if (selectedUser.Age <= 12)
                {
                    discountType = DiscountType.Child;
                }

                // Create FlyerSelection object for each user
                selectedFlyers.Add(new FlyerSelection
                {
                    Customer = selectedUser,
                    Flyer = true, // By default, no users are selected
                    DiscountType = discountType // Assign the determined discount type
                });
            }


            var reservationEmbryo = new ReservationEmbryo()
            {
                //Flyers = selectedUsers.Select(user => new FlyerSelection
                //{
                //    Customer = user,
                //    Flyer = true
                //}).ToList(),
                Flyers = selectedFlyers,
                Flight = existingFlight
            };

            return View("SeatSelection", reservationEmbryo);
        }

        [HttpGet]
        public IActionResult ConfirmSeatSelection(List<FlyerSelection> flyers, Flight flight)
        {
            TempData["Flyers"] = flyers;
            TempData["Flight"] = flight;

            return RedirectToAction("ConfirmSeatSelection");
        }

        [HttpPost]
        public IActionResult ConfirmSeatSelection()
        {
            var flyers = TempData["Flyers"] as List<FlyerSelection>;
            var flight = TempData["Flight"] as Flight;

            if (flyers == null || flight == null)
            {
                // Handle the case when TempData is null or the objects are not found
                // Redirect to an appropriate action or return an error view
            }

            var reservationEmbryo = new ReservationEmbryo
            {
                Flyers = flyers,
                Flight = flight
            };

            return View(reservationEmbryo);

        }









        //[HttpGet]
        [Authorize(Roles = "Manager,Agent")]
        public async Task<IActionResult> CheckIn(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Flight flight = await _context.Flights
                .Include(f => f.FlightPath)
                .Include(t => t.Tickets)
                .ThenInclude(U => U.TicketHolder)
                .FirstOrDefaultAsync(m => m.FlightID == id);

            if (flight == null)
            {
                return NotFound();
            }

            //if (flight.status == Status.Departed)
            //{
            //    return View("DepartedFlightManifest", flight);
            //}
            //else if (flight.status == Status.OnTime)
            //{
            //    return View("FutureFlightManifest", flight);
            //}

            

            return View(flight);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager,Agent")]
        public async Task<IActionResult> CheckIn(int id, int[] ticketIds)
        {

            // Retrieve the flight from the database
            Flight flight = await _context.Flights
                .Include(f => f.Tickets)
                .ThenInclude(t => t.TicketHolder)
                .Include(f => f.FlightPath)
                .FirstOrDefaultAsync(m => m.FlightID == id);

            if (flight == null)
            {
                return NotFound();
            }


            // Update the check-in status for each ticket
            if (ticketIds != null)
            {
                foreach (var ticketId in ticketIds)
                {
                    Ticket ticket = flight.Tickets.FirstOrDefault(t => t.TicketID == ticketId);
                    Ticket dbTicket = _context.Tickets
                                    .FirstOrDefault(t => t.TicketID == ticket.TicketID);
                    dbTicket.CheckIn = !ticket.CheckIn;
                    _context.Tickets.Update(dbTicket);

                    //if (ticket != null)
                    //{
                    //    // Toggle the check-in status
                    //    //ticket.CheckIn = !ticket.CheckIn;
                    //    Ticket dbTicket = _context.Tickets
                    //                .FirstOrDefault(t => t.TicketID == ticket.TicketID);
                    //    dbTicket.CheckIn = ticket.CheckIn;
                    //    _context.Tickets.Update(dbTicket);

                    //}

                }

            }

            // Save changes to the database
            flight.status = Status.Departed;

            foreach (var ticket in flight.Tickets)
            {
                if (ticket.TicketStatus == TicketStatus.Active && ticket.CheckIn == true)
                {
                    // Retrieve the flight path to get the distance
                    var flightPath = await _context.FlightPaths.FindAsync(flight.FlightPath.FlightPathID);
                    if (flightPath != null)
                    {
                        // Calculate miles earned based on distance
                        if(ticket.TicketPaymentType == TicketPaymentType.Cash)
                        {
                            ticket.MilesEarned = flightPath.Distance;
                            ticket.TicketHolder.Miles = ticket.TicketHolder.Miles + flightPath.Distance;
                        }

                        _context.Entry(ticket.TicketHolder).State = EntityState.Modified;
                    }
                }
            }

            await _context.SaveChangesAsync();
            //await UpdateFlightStatuses();
            
            // Redirect to the flight details page
            return RedirectToAction(nameof(Index), new { id = flight.FlightID });
        }

      
        public async Task<IActionResult> UndoCheckIn(int id)
        {
            // Retrieve the ticket from the database
            //Ticket ticket = await _context.Tickets.FindAsync(id);

            Ticket ticket = await _context.Tickets
                .Include(f => f.Flight)
                .Include(U => U.TicketHolder)
                .FirstOrDefaultAsync(m => m.TicketID == id);

            // Check if the ticket exists
            if (ticket == null)
            {
                return NotFound();
            }

            // Update the CheckIn status to false
            ticket.CheckIn = false;

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect back to the flight details page
            return RedirectToAction(nameof(CheckIn), new { id = ticket.Flight.FlightID }); // Assuming FlightDetails action exists and accepts flight ID as parameter
        }





        private async Task UpdateFlightStatuses()
        {
            // Retrieve flights that have departure time in the past and their status is not "Departed"
            var pastFlights = await _context.Flights
                .Include(t => t.Tickets)
                .ThenInclude(th => th.TicketHolder)
                .Include(fp => fp.FlightPath)
                .Where(f => f.DepartureTime < DateTime.Now)
                .ToListAsync();

            // Update the status of past flights to "Departed"
            foreach (var flight in pastFlights)
            {
                flight.status = Status.Departed;
                _context.Update(flight);

                foreach (var ticket in flight.Tickets)
                {
                    if (ticket.TicketStatus == TicketStatus.Active)
                    {
                        // Retrieve the flight path to get the distance
                        var flightPath = await _context.FlightPaths.FindAsync(flight.FlightPath.FlightPathID);
                        if (flightPath != null)
                        {
                            // Calculate miles earned based on distance
                            ticket.MilesEarned = flightPath.Distance;
                            ticket.TicketHolder.Miles = ticket.TicketHolder.Miles + flightPath.Distance;
                            _context.Entry(ticket.TicketHolder).State = EntityState.Modified;
                        }
                    }
                }
            }

            // Save changes to the database
            await _context.SaveChangesAsync();
        }

        private SelectList GetFlightPathSelectList()
        {
            //create a list for all the courses
            List<FlightPath> allFlightPaths = _context.FlightPaths.ToList();

            //the user MUST select a course, so you don't need a dummy option for no course

            //use the constructor on select list to create a new select list with the options
            SelectList slAllFlightPaths = new SelectList(allFlightPaths, nameof(FlightPath.FlightPathID), nameof(FlightPath.FlightPathName));

            return slAllFlightPaths;
        }


    }




}




