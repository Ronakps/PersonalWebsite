using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group5_LonghornAirlines_FinalProject.DAL;
using Group5_LonghornAirlines_FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Sockets;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Group5_LonghornAirlines_FinalProject.Controllers
{
    public class TicketsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public TicketsController(AppDbContext context, UserManager<AppUser> userManger)
        {
            _context = context;
            _userManager = userManger;
        }

        // GET: Tickets
        public IActionResult Index(int? reservationID)
        {
            if (reservationID == null)
            {
                return View("Error", new String[] { "Please specify a reservation to view!" });
            }

            //limit the list to only the registration details that belong to this registration
            List<Ticket> tks = _context.Tickets
                                          .Include(tk => tk.Flight)
                                          .ThenInclude(f => f.FlightPath)
                                          .Include(tk => tk.TicketHolder)
                                          .Include(tk => tk.Reservation)
                                          .Where(tk => tk.Reservation.ReservationID == reservationID)
                                          .ToList();

            return View(tks);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.TicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        // GET: Tickets/Create
        public async Task<IActionResult> Start(int reservationId, int flightId)
        {

            if (flightId != 0)
            {
                Flight flight = _context.Flights
                            .Include(f => f.FlightPath) // Assuming "FlightPath" is the navigation property
                            .FirstOrDefault(f => f.FlightID == flightId);

                String flightDetails = "" + flight.DepartureTime.ToString() + " " + flight.FlightPath.DepartureCity.ToString() + " - " + flight.FlightPath.ArrivalCity.ToString();
                TempData["ChosenFlightMessage"] = "It seems like you wanted to initially purchase this flight: " + flightDetails + ". WARNING: If your chosen flight overlaps with your other tickets should you have any, your flight will not be available. Can you confirm this in the drop down above?";
            }

            // Check if TempData contains a message
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"].ToString();
            }

            //create a new instance of the RegistrationDetail class
            Ticket tk = new Ticket();

            //find the registration that should be associated with this registration
            Reservation res = _context.Reservations.Find(reservationId);

            //set the new registration detail's registration equal to the registration you just found
            tk.Reservation = res;

            //populate the ViewBag with a list of existing courses
            ViewBag.UserNames = await GetAllCustomerUserNamesSelectList();

            //pass the newly created registration detail to the view
            return View("SelectCustomerForTicket", tk); ;
        }

        //[HttpPost]
        public IActionResult SelectCustomerForTicket(Ticket ticket, String SelectedCustomer)
        {
            ViewBag.ChosenFlightMessage = TempData["ChosenFlightMessage"] != null ? TempData["ChosenFlightMessage"].ToString() : "";

            var existingTicket = _context.Tickets.FirstOrDefault(t =>
                t.Reservation.ReservationID == ticket.Reservation.ReservationID &&
                t.TicketHolder.UserName == SelectedCustomer);

            if (existingTicket != null)
            {
                TempData["Message"] = "You have already made a ticket for this reservation. Please choose another customer.";
                return RedirectToAction("Start", new { reservationId = ticket.Reservation.ReservationID });
            }

            var customer = _userManager.FindByNameAsync(SelectedCustomer).Result;
            if (customer == null)
            {
                TempData["Message"] = "Customer not found. Please select a valid customer.";
                return RedirectToAction("Start", new { reservationId = ticket.Reservation.ReservationID });
            }

            Ticket tk = new Ticket
            {
                TicketHolder = customer,
                Reservation = _context.Reservations.Find(ticket.Reservation.ReservationID)
            };

            ViewBag.AllFlights = GetFlightSelectList(customer.Id);
            return View("Create", tk);
        }




        public async Task<IActionResult> ChooseSeat(int SelectedFlight, Ticket tk)
        {
            tk.Flight = await _context.Flights.FindAsync(SelectedFlight);
            if (tk.Flight == null)
            {
                ViewBag.ErrorMessage = "The selected flight does not exist. Please select a different flight.";
                ViewBag.AllFlights = GetFlightSelectList(tk.TicketHolder.Id);
                return View("Create", tk);
            }

            var availableSeats = await GetAvailableSeatsForFlight(SelectedFlight);
            if (!availableSeats.Any())
            {
                ViewBag.ErrorMessage = "There are no available seats on the selected flight. Please choose a different flight.";
                ViewBag.AllFlights = GetFlightSelectList(tk.TicketHolder.Id);
                return View("Create", tk);
            }

            ViewBag.AvailableSeats = availableSeats;
            return View("ChooseSeatOnFlight", tk);
        }





        public async Task<List<Seat>> GetAvailableSeatsForFlight(int flightId)
        {
            // Find the flight based on the flightId
            var flight = await _context.Flights
                .Include(f => f.Tickets) // Include the Tickets navigation property
                .FirstOrDefaultAsync(f => f.FlightID == flightId);

            if (flight == null)
            {
                // Flight not found
                return new List<Seat>(); // Return an empty list
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

            return availableSeats;
        }

        public async Task<List<Seat>> GetAvailableUpgradeSeatsForFlight(int flightId)
        {
            // Find the flight based on the flightId
            var flight = await _context.Flights
                .Include(f => f.Tickets) // Include the Tickets navigation property
                .FirstOrDefaultAsync(f => f.FlightID == flightId);

            if (flight == null)
            {
                // Flight not found
                return new List<Seat>(); // Return an empty list
            }

            // Get all possible seats for the given flight’s aircraft
            //var allSeats = Enum.GetValues(typeof(Seat)).Cast<Seat>().ToList(); // Assuming Seat is an enum
            var selectedSeats = Enum.GetValues(typeof(Seat))
                        .Cast<Seat>()
                        .Where(seat => seat == Seat.A1 || seat == Seat.B1 || seat == Seat.A2 || seat == Seat.B2)
                        .ToList();


            // Get booked seats with an Active status for the given flight
            var activeBookedSeats = flight.Tickets
                                          .Where(t => t.TicketStatus == TicketStatus.Active)
                                          .Select(t => t.Seat)
                                          .ToList();

            // Find available seats by excluding actively booked seats
            var availableSeats = selectedSeats.Except(activeBookedSeats).ToList();

            return availableSeats;
        }

        public async Task<List<Seat>> GetAvailableEconomySeatsForFlight(int flightId)
        {
            // Find the flight based on the flightId
            var flight = await _context.Flights
                .Include(f => f.Tickets) // Include the Tickets navigation property
                .FirstOrDefaultAsync(f => f.FlightID == flightId);

            if (flight == null)
            {
                // Flight not found
                return new List<Seat>(); // Return an empty list
            }

            // Get all possible seats for the given flight’s aircraft
            //var allSeats = Enum.GetValues(typeof(Seat)).Cast<Seat>().ToList(); // Assuming Seat is an enum
            var selectedSeats = Enum.GetValues(typeof(Seat))
                        .Cast<Seat>()
                        .Where(seat => !(seat == Seat.A1 || seat == Seat.B1 || seat == Seat.A2 || seat == Seat.B2))
                        .ToList();


            // Get booked seats with an Active status for the given flight
            var activeBookedSeats = flight.Tickets
                                          .Where(t => t.TicketStatus == TicketStatus.Active)
                                          .Select(t => t.Seat)
                                          .ToList();

            // Find available seats by excluding actively booked seats
            var availableSeats = selectedSeats.Except(activeBookedSeats).ToList();

            return availableSeats;
        }


        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            //Seat tempSeat = ticket.Seat; 

            Decimal tempPrice = ticket.Price;

            Decimal tempMiles = ticket.PriceInMiles;

            Flight dbFlight = _context.Flights.Find(ticket.Flight.FlightID);

            AppUser dbAppUser = await _userManager.FindByNameAsync(ticket.TicketHolder.UserName);

            //Reservation dbReservation = _context.Reservations.Find(ticket.Reservation.ReservationID);

            Reservation dbReservation = await _context.Reservations
                                            .Include(r => r.User) // Include the User navigational property
                                            .FirstOrDefaultAsync(r => r.ReservationID == ticket.Reservation.ReservationID);


            dbReservation.ReservationStatus = ReservationStatus.Pending;
            _context.Update(dbReservation);
            _context.SaveChanges();

            ticket.Flight = dbFlight;

            ticket.TicketHolder = dbAppUser;

            ticket.Reservation = dbReservation;

            //set the registration detail's price equal to the course price
            //this will allow us to to store the price that the user paid
            ticket.TicketStatus = TicketStatus.Pending;
            ticket.DiscountType = GetDiscountType(ticket);
            ticket.CheckIn = false;
            ticket.TicketDate = DateTime.Now;
            ticket.SeatStatus = GetSeatStatus(ticket);
            ticket.MilesEarned = 0;
            //ticket.TicketPaymentType = (TicketPaymentType)ticket.Reservation.PaymentType;
            //ticket.ModificationFee = 0;

            if(!ticket.Upgraded)
            {
                ticket.TicketPaymentType = (TicketPaymentType)ticket.Reservation.PaymentType;

                if (ticket.Reservation.PaymentType == PaymentType.Cash)
                {
                    ticket.Price = Math.Max(CalculatePriceAfterDiscountsAndUpgrades(ticket, dbFlight.EconomyPrice), tempPrice);
                    ticket.PriceInMiles = 0;

                    if (ticket.Price == tempPrice)
                    {
                        String buildMessage = "The prices in the below table may not be accurate because you changed your seat. The price you will be paying is $" + tempPrice.ToString() + ".";
                        TempData["ChangeSeatMessage"] = buildMessage;
                    }

                    TempData["Upgrades"] = ViewBagUpgrades(ticket, dbFlight.EconomyPrice).ToString();
                    TempData["Discounts"] = ViewBagDiscount(ticket, dbFlight.EconomyPrice).ToString();
                    TempData["BaseFlightPrice"] = dbFlight.EconomyPrice.ToString();
                    TempData["ModificationFee"] = ticket.ModificationFee.ToString();
                }
                else
                {
                    var milesRequired = Math.Max(GetNumberOfMilesRequired(ticket), tempMiles);

                    if (ticket.Reservation.User.Miles < milesRequired)
                    {
                        // Set a TempData message to indicate that the user already has a ticket
                        TempData["MilesMessage"] = "You don't have enough miles to proceed with this selction. Please try again or edit your payment method by clicking the Edit button.";
                        // If a ticket already exists, redirect the user to the Start action method
                        return RedirectToAction("Details", "Reservation", new { id = ticket.Reservation.ReservationID });

                        //ViewBag.ErrorMessage = "You don't have enough miles to make this reservation! Please choose to pay with cash.";
                        //return RedirectToAction("Create", "Reservations", new { ErrorMessage = ViewBag.ErrorMessage });

                        //TempData["ErrorMessage"] = "You don't have enough miles to make this reservation! Please choose to pay with cash.";
                        // Store the reservation object in TempData
                        //TempData["Reservation"] = ticket.Reservation;
                        // Redirect to the Reservations/Create view
                        // return RedirectToAction("CreatePost", "Reservation", new { reservation = ticket.Reservation });
                        //return View(ticket);
                    }
                    else
                    {
                        ticket.PriceInMiles = milesRequired;
                        TempData["MilesToPurchase"] = ticket.PriceInMiles.ToString();
                    }
                }
            }
            else
            {
                ticket.Price = tempPrice;
                ticket.PriceInMiles += 500;
                TempData["MilesToPurchase"] = ticket.PriceInMiles.ToString();

            }
            

            //add the registration detail to the database
            _context.Add(ticket);
            await _context.SaveChangesAsync();

            //Send the email to confirm order details have been added 


            //send the user to the details page for this registration
            return RedirectToAction("CheckoutReservation", "Reservation", new { id = ticket.Reservation.ReservationID, ticketId = ticket.TicketID });

        }

        //Helper method to get the number of Miles Required
        public Decimal GetNumberOfMilesRequired(Ticket ticket)
        {
            var milesRequired = 0;

            if(ticket.SeatStatus == SeatStatus.Economy)
            {
                milesRequired = 1000;
            }
            else
            {
                milesRequired = 2000;
            }

            return milesRequired;
        }

        //Helper method to get discount type
        public DiscountType GetDiscountType(Ticket ticket)
        {
            if (ticket.TicketHolder != null && ticket.TicketHolder.Age.HasValue)
            {
                if (ticket.TicketHolder.Age >= 65)
                {
                    return DiscountType.Senior;
                }
                else if (ticket.TicketHolder.Age <= 12)
                {
                    
                    return DiscountType.Child;
                }
                else
                {
                    return DiscountType.None;
                }
            }

            return DiscountType.None;
        }

        //Helper method to calculate price
        public Decimal CalculatePriceAfterDiscountsAndUpgrades(Ticket ticket, Decimal basePrice)
        {
            Decimal adjustedPrice = basePrice;

            if (ticket.Seat.ToString() == "A1" || ticket.Seat.ToString() == "A2" || ticket.Seat.ToString() == "B1" || ticket.Seat.ToString() == "B2")
            {
                adjustedPrice *= 1.2m;
            }
            else
            {
                if (ticket.TicketHolder != null && ticket.TicketHolder.Age.HasValue)
                {
                    if (ticket.TicketHolder.Age >= 65)
                    {
                        adjustedPrice *= 0.9m;
                        //ticket.DiscountType = DiscountType.Senior;
                    }
                    else if (ticket.TicketHolder.Age <= 12)
                    {
                        adjustedPrice *= 0.85m;
                        //ticket.DiscountType = DiscountType.Child;
                    }
                    else
                    {
                        //ticket.DiscountType = DiscountType.None;
                    }
                }
            }

            return adjustedPrice;
        }

        //Helper method to calculate discount amount
        public Decimal ViewBagDiscount(Ticket ticket, Decimal basePrice)
        {
            Decimal discountedPrice = 0;

            
            if (ticket.TicketHolder != null && ticket.TicketHolder.Age.HasValue)
            {
                if (ticket.TicketHolder.Age >= 65)
                {
                    discountedPrice = basePrice * 0.1m;
                }
                else if (ticket.TicketHolder.Age <= 12)
                {
                    discountedPrice = basePrice * 0.15m;
                    //ticket.DiscountType = DiscountType.Child;
                }
            }
            
            return discountedPrice;
        }

        //Helper method to calculate upgrade amount
        public Decimal ViewBagUpgrades(Ticket ticket, Decimal basePrice)
        {
            Decimal upgrades = 0;

            if (ticket.Seat.ToString() == "A1" || ticket.Seat.ToString() == "A2" || ticket.Seat.ToString() == "B1" || ticket.Seat.ToString() == "B2")
            {
                upgrades = basePrice * 0.2m;
            }

            return upgrades;
        }

        //Helper method to determine seat status
        public SeatStatus GetSeatStatus(Ticket ticket)
        {
            if (ticket.Seat.ToString() == "A1" || ticket.Seat.ToString() == "A2" || ticket.Seat.ToString() == "B1" || ticket.Seat.ToString() == "B2")
            {
                return SeatStatus.FirstClass;
            }

            return SeatStatus.Economy;
        }

        public async Task<IActionResult> ChooseNewSeat(int flightId, int ticketId)
        {
            //Ticket tk1 = await _context.Tickets
            //                              .Include(tk => tk.Flight)
            //                              .ThenInclude(f => f.FlightPath)
            //                              .Include(tk => tk.Reservation)
            //                              .Include(tk => tk.TicketHolder)
            //                              .FirstOrDefaultAsync(tk => tk.TicketID == ticketId);

            Ticket tk = await _context.Tickets
                                          .Include(tk => tk.Flight)
                                          .ThenInclude(f => f.FlightPath)
                                          .Include(tk => tk.Reservation)
                                          .Include(tk => tk.TicketHolder)
                                          .FirstOrDefaultAsync(tk => tk.TicketID == ticketId);

            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }

            await _context.SaveChangesAsync();

            tk.Flight = _context.Flights.Find(flightId);

            // Assuming you have a method to retrieve available seats based on the selected flight
            var availableSeats = await GetAvailableSeatsForFlight(flightId);
            // Pass the list of available seats to the view
            ViewBag.AvailableSeats = availableSeats;

            return View("ChooseSeatOnFlight", tk);


        }

        public async Task<IActionResult> ChooseUpgradedSeat(int flightId, int ticketId)
        {
            //Ticket tk1 = await _context.Tickets
            //                              .Include(tk => tk.Flight)
            //                              .ThenInclude(f => f.FlightPath)
            //                              .Include(tk => tk.Reservation)
            //                              .Include(tk => tk.TicketHolder)
            //                              .FirstOrDefaultAsync(tk => tk.TicketID == ticketId);

            Ticket tk = await _context.Tickets
                                          .Include(tk => tk.Flight)
                                          .ThenInclude(f => f.FlightPath)
                                          .Include(tk => tk.Reservation)
                                          .Include(tk => tk.TicketHolder)
                                          .FirstOrDefaultAsync(tk => tk.TicketID == ticketId);

            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }

            await _context.SaveChangesAsync();

            tk.Flight = _context.Flights.Find(flightId);
            tk.Upgraded = true;

            // Assuming you have a method to retrieve available seats based on the selected flight
            var availableSeats = await GetAvailableUpgradeSeatsForFlight(flightId);
            // Pass the list of available seats to the view
            ViewBag.AvailableSeats = availableSeats;
            return View("ChooseSeatOnFlight", tk);


        }


        public async Task<IActionResult> ChooseMilesFCSeat(int flightId, int ticketId)
        {
            //Ticket tk1 = await _context.Tickets
            //                              .Include(tk => tk.Flight)
            //                              .ThenInclude(f => f.FlightPath)
            //                              .Include(tk => tk.Reservation)
            //                              .Include(tk => tk.TicketHolder)
            //                              .FirstOrDefaultAsync(tk => tk.TicketID == ticketId);

            Ticket tk = await _context.Tickets
                                          .Include(tk => tk.Flight)
                                          .ThenInclude(f => f.FlightPath)
                                          .Include(tk => tk.Reservation)
                                          .ThenInclude(r => r.User)
                                          .Include(tk => tk.TicketHolder)
                                          .FirstOrDefaultAsync(tk => tk.TicketID == ticketId);

            var ticket = await _context.Tickets.FindAsync(ticketId);

            ticket.Reservation.User.Miles += 2000;

            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }

            await _context.SaveChangesAsync();

            tk.Flight = _context.Flights.Find(flightId);


            // Assuming you have a method to retrieve available seats based on the selected flight
            var availableSeats = await GetAvailableSeatsForFlight(flightId);
            // Pass the list of available seats to the view
            ViewBag.AvailableSeats = availableSeats;
            return View("ChooseSeatOnFlight", tk);


        }


        public async Task<IActionResult> ChooseEconomySeat(int flightId, int ticketId)
        {
            //Ticket tk1 = await _context.Tickets
            //                              .Include(tk => tk.Flight)
            //                              .ThenInclude(f => f.FlightPath)
            //                              .Include(tk => tk.Reservation)
            //                              .Include(tk => tk.TicketHolder)
            //                              .FirstOrDefaultAsync(tk => tk.TicketID == ticketId);

            Ticket tk = await _context.Tickets
                                          .Include(tk => tk.Flight)
                                          .ThenInclude(f => f.FlightPath)
                                          .Include(tk => tk.Reservation)
                                          .ThenInclude(r => r.User)
                                          .Include(tk => tk.TicketHolder)
                                          .FirstOrDefaultAsync(tk => tk.TicketID == ticketId);

            var ticket = await _context.Tickets.FindAsync(ticketId);

            ticket.Reservation.User.Miles += 1000;

            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }

            await _context.SaveChangesAsync();

            tk.Flight = _context.Flights.Find(flightId);


            // Assuming you have a method to retrieve available seats based on the selected flight
            var availableSeats = await GetAvailableEconomySeatsForFlight(flightId);
            // Pass the list of available seats to the view
            ViewBag.AvailableSeats = availableSeats;
            return View("ChooseSeatOnFlight", tk);


        }

        public async Task<IActionResult> ChangeFlight(int flightId, int ticketId)
        {
            Ticket tk = await _context.Tickets
                                      .Include(tk => tk.Flight)
                                      .ThenInclude(f => f.FlightPath)
                                      .Include(tk => tk.Reservation)
                                      .Include(tk => tk.TicketHolder)
                                      .FirstOrDefaultAsync(tk => tk.TicketID == ticketId);

            if (tk == null)
            {
                return NotFound("Ticket not found.");
            }

            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }

            if (tk.TicketStatus == TicketStatus.Active)
            {
                tk.ModificationFee = 50;  // Assuming a fee is applied for changing an active ticket
            }

            // Get flights that do not overlap with this user's existing tickets
            ViewBag.AllFlights = GetFlightSelectList(tk.TicketHolder.Id);  // Adjust GetFlightSelectList to accept userId

            return View("Create", tk);
        }


        // GET: Tickets/CheckoutPending/5
        public async Task<IActionResult> CheckoutPending(int? id)
        {
            Ticket ticket = await _context.Tickets
                                          .Include(tk => tk.Flight)
                                          .ThenInclude(f => f.FlightPath)
                                          .Include(tk => tk.Reservation)
                                          .FirstOrDefaultAsync(tk => tk.TicketID == id);

            Flight dbFlight = _context.Flights.Find(ticket.Flight.FlightID);

            if (id == null)
            {
                return NotFound();
            }

            //var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            if (ticket.Reservation.PaymentType == PaymentType.Cash)
            {
                ticket.Price = CalculatePriceAfterDiscountsAndUpgrades(ticket, dbFlight.EconomyPrice);

                TempData["Upgrades"] = ViewBagUpgrades(ticket, dbFlight.EconomyPrice).ToString();
                TempData["Discounts"] = ViewBagDiscount(ticket, dbFlight.EconomyPrice).ToString();
                TempData["BaseFlightPrice"] = dbFlight.EconomyPrice.ToString();
            }
            else
            {
                var milesRequired = GetNumberOfMilesRequired(ticket);
            }

            return RedirectToAction("CheckoutReservation", "Reservation", new { id = ticket.Reservation.ReservationID, ticketId = ticket.TicketID });
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckoutPending(int id, [Bind("TicketID,TicketStatus,Price,DiscountType,CheckIn,TicketDate,Seat,SeatStatus,MilesEarned,ModificationFee")] Ticket ticket)
        {
            if (id != ticket.TicketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(t => t.TicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Ticket ticket = await _context.Tickets
                                       .Include(tk => tk.Flight)
                                       .ThenInclude(f => f.FlightPath)
                                       .Include(tk => tk.Reservation)
                                       .ThenInclude(r => r.User)
                                       .Include(tk => tk.TicketHolder)
                                       .FirstOrDefaultAsync(tk => tk.TicketID == id);
            if (ticket.Reservation == null || ticket.Flight == null || ticket.TicketHolder == null)
            {
                // Handle the case where associated data is not loaded properly
                return NotFound("Associated data is missing.");
            }

            if (ticket != null)
            {
                // Retrieve the associated reservation
                var reservation = ticket.Reservation;

                string primaryTravelerEmail = ticket.TicketHolder.Email;
                // Update the ticket status to "Canceled"

                ticket.TicketStatus = TicketStatus.Canceled;
             
                // Refund miles to the reservation holder if payment type was in miles
                if (ticket.Reservation.PaymentType == PaymentType.Miles)
                {
                    reservation.User.Miles += (int)ticket.PriceInMiles;
                }

                // Send email notification to the user whose ticket got deleted
                string deletedTicketMessage = $"Hello {ticket.TicketHolder.FirstName} {ticket.TicketHolder.LastName},\n\nYour flight reservation for Flight: {ticket.Flight.FlightNumber} has been canceled for {ticket.Flight.DepartureTime}. The ticket for {ticket.TicketHolder.FirstName} has been cancelled.\n\n Thank you and fly again with us! ";
                Utilities.EmailMessaging.SendEmail("Ticket Cancellation", deletedTicketMessage, primaryTravelerEmail);

                // Send email notification to the reservation holder
                string reservationHolderMessage = $"Hello {reservation.User.FirstName} {reservation.User.LastName},\n\nA ticket associated with your reservation for Flight: {ticket.Flight.FlightNumber} has been canceled for {ticket.Flight.DepartureTime}. If you have any questions, please contact us.\n\n Thank you! ";
                Utilities.EmailMessaging.SendEmail("Ticket Cancellation", reservationHolderMessage, primaryTravelerEmail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { reservationID = ticket.Reservation.ReservationID });
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var ticket = await _context.Tickets
        //                               .Include(tk => tk.Flight)
        //                               .ThenInclude(f => f.FlightPath)
        //                               .Include(tk => tk.Reservation)
        //                               .ThenInclude(r => r.User)
        //                               .FirstOrDefaultAsync(tk => tk.TicketID == id);
        //    if (ticket != null)
        //    {
        //        ticket.TicketStatus = TicketStatus.Canceled;
        //        ticket.Reservation.User.Miles += (int)ticket.PriceInMiles;
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index), new { reservationID = ticket.Reservation.ReservationID });
        //}


        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketID == id);
        }


        public SelectList GetFlightSelectList(string userId)
        {
            var userTickets = _context.Tickets
                .Include(t => t.Flight)
                .ThenInclude(f => f.FlightPath)
                .Where(t => t.TicketHolder.Id == userId && t.TicketStatus != TicketStatus.Canceled)
                .ToList();

            // Current time plus one hour to set the minimum allowable departure time
            var minimumDepartureTime = DateTime.Now.AddHours(1);

            var futureFlights = _context.Flights
                .Include(flight => flight.FlightPath)
                .Where(flight => flight.DepartureTime > minimumDepartureTime) 
                .Where(flight => flight.status != Status.Departed)
                .Where(flight => flight.status != Status.Canceled)
                .ToList();

            var nonOverlappingFlights = futureFlights.Where(flight =>
                !userTickets.Any(ticket =>
                    ticket.Flight.DepartureTime < flight.CalculateArrivalTime() &&
                    flight.DepartureTime < ticket.Flight.CalculateArrivalTime()))
                .ToList();

            List<SelectListItem> customFlightList = new List<SelectListItem>();
            foreach (var flight in nonOverlappingFlights)
            {
                String departureCity = flight.FlightPath != null ? Enum.GetName(typeof(City), flight.FlightPath.DepartureCity) : "Unknown";
                String arrivalCity = flight.FlightPath != null ? Enum.GetName(typeof(City), flight.FlightPath.ArrivalCity) : "Unknown";
                String displayText = $"{flight.DepartureTime.ToString("yyyy-MM-dd HH:mm")} - {departureCity} to {arrivalCity}";

                customFlightList.Add(new SelectListItem { Value = flight.FlightID.ToString(), Text = displayText });
            }

            return new SelectList(customFlightList, "Value", "Text");
        }




        public async Task<SelectList> GetAllCustomerUserNamesSelectList()
        {
            //create a list to hold the customers
            List<AppUser> allCustomers = new List<AppUser>();

            //See if the user is a customer
            foreach (AppUser dbUser in _context.Users)
            {
                if (dbUser.ActiveStatus == true)
                {
                    //if the user is a customer, add them to the list of customers
                    if (await _userManager.IsInRoleAsync(dbUser, "Customer") == true)//user is a customer
                    {
                        allCustomers.Add(dbUser);
                    }
                }
                else { }
            }

            // Create a new list of SelectListItem to hold the custom display values
            List<SelectListItem> customUserList = new List<SelectListItem>();

            // Iterate through each flight and create a custom display string
            foreach (var user in allCustomers)
            {
                
                String displayText = $"{user.FirstName} {user.LastName} - {user.Email}";

                //String displayText = $"{flight.DepartureTime.ToString("yyyy-MM-dd HH:mm")} - {flight.FlightPath.DepartureCity.ToString()} to {flight.FlightPath.ArrivalCity.ToString()}";
                customUserList.Add(new SelectListItem { Value = user.UserName, Text = displayText });
            }

            //create a new select list with the customer emails
            //SelectList sl = new SelectList(allCustomers.OrderBy(c => c.Email), nameof(AppUser.UserName), nameof(AppUser.Email));

            SelectList slAllCustomers = new SelectList(customUserList, "Value", "Text");

            return slAllCustomers;

            //return the select list
            // return sl;

        }
        //public async Task<SelectList> GetAllCustomerUserNamesSelectList()
        //{
        //    //create a list to hold the customers
        //    List<AppUser> allCustomers = new List<AppUser>();

        //    //See if the user is a customer
        //    foreach (AppUser dbUser in _context.Users)
        //    {
        //        //if the user is a customer, add them to the list of customers
        //        if (await _userManager.IsInRoleAsync(dbUser, "Customer") == true)//user is a customer
        //        {
        //            allCustomers.Add(dbUser);
        //        }
        //    }

        //    //create a new select list with the customer emails
        //    SelectList sl = new SelectList(allCustomers.OrderBy(c => c.Email), nameof(AppUser.UserName), nameof(AppUser.Email));

        //    //return the select list
        //    return sl;

        //}
    }
}

//[HttpPost]
//public async Task<IActionResult> SelectFlightForTicket(Ticket ticket, int selectedFlight)
//{
//    Ticket tk = new Ticket();
//    Reservation res = await _context.Reservations.FindAsync(ticket.Reservation.ReservationID);
//    AppUser customer = await _userManager.FindByNameAsync(ticket.TicketHolder.UserName);
//    Flight flight = await _context.Flights.FindAsync(selectedFlight);

//    tk.TicketHolder = customer;
//    tk.Reservation = res;
//    // Find the selected flight

//    //if (flight == null)
//    //{
//    //    // Handle case where flight is not found
//    //}

//    // Set flight for the ticket
//    tk.Flight = flight;

//    // Pass ticket to the final step
//    return View("Create", tk);
//}


//[HttpGet]
//public async Task<IActionResult> SelectFlightForTicket(Ticket ticket)
//{
//    //if (String.IsNullOrEmpty(SelectedCustomer))
//    //{
//    //    ViewBag.UserNames = GetAllCustomerUserNamesSelectList();
//    //    return View("SelectCustomerForTicket");
//    //}
//    //Ticket tk = new Ticket();
//    //Flight dbFlight = _context.Flights.Find(SelectedFlight);
//    //tk.Flight = dbFlight;
//    //ViewBag.UserNames = GetAllCustomerUserNamesSelectList();
//    Ticket tk = new Ticket();
//    Reservation res = await _context.Reservations.FindAsync(ticket.Reservation.ReservationID);
//    AppUser customer = await _userManager.FindByNameAsync(ticket.TicketHolder.UserName);

//    tk.TicketHolder = customer;
//    tk.Reservation = res;

//    ViewBag.AllFlights = GetFlightSelectList();

//    return View(ticket);
//}

