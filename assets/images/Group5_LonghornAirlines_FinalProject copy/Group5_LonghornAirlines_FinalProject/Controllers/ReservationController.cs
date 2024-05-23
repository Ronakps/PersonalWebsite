using Group5_LonghornAirlines_FinalProject.DAL;
using Group5_LonghornAirlines_FinalProject.Models;
using Group5_LonghornAirlines_FinalProject.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Group5_LonghornAirlines_FinalProject.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(AppDbContext context, UserManager<AppUser> userManger)
        {
            _context = context;
            _userManager = userManger;
        }

        // GET: Reservation
        public async Task<IActionResult> Index(string searchString)
        {
            // LINQ query to retrieve flights from the database
            var query = _context.Reservations
                        .Include(r => r.Tickets)
                        .ThenInclude(t => t.Flight)
                                .AsQueryable();  // Ensure the query remains IQueryable




            // Apply search filter if searchString is not null or empty
            if (!string.IsNullOrEmpty(searchString))
            {
                // Modify the query to filter by ReservationNumber
                query = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Reservation, Flight>)query.Where(r => r.ReservationNumber.ToString().Contains(searchString));
            }


            if (User.IsInRole("Customer"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Using user ID from claims

                query = query.Where(r => r.User.Id == userId || r.Tickets.Any(t => t.TicketHolder.Id == userId));
            }

            var reservations = await query.ToListAsync();


            // Set ViewBag values
            ViewBag.TotalReservationsCount = await _context.Reservations.CountAsync();
            ViewBag.SelectedReservationCount = reservations.Count;


            // Pass the reservations to the view
            return View(reservations);
        }




        // GET: Reservation/Details/5
        public async Task<IActionResult> Details(int? id, Int32? requestedFlightNumParam)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (TempData.ContainsKey("MilesMessage"))
            {
                ViewBag.MilesMessage = TempData["MilesMessage"].ToString();
            }

            var reservation = await _context.Reservations
                .Include(r => r.User)
                .Include(r => r.Tickets)
                    .ThenInclude(t => t.Flight)
                        .ThenInclude(f => f.FlightPath) // Include FlightPath
                    .Include(r => r.Tickets) // Include tickets
                        .ThenInclude(t => t.TicketHolder) // Include TicketHolder (assuming this is AppUser)
                .FirstOrDefaultAsync(r => r.ReservationID == id);

            reservation.RequestedFlightNum = requestedFlightNumParam;

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }


        // GET: Reservation/Create
        public async Task<IActionResult> Create(int flightid)
        {
            //if (TempData.ContainsKey("MilesMessage"))
            //{
            //    ViewBag.MilesMessage = TempData["MilesMessage"].ToString();
            //}

            if (User.IsInRole("Customer"))
            {
                Reservation reservation = new Reservation();
                reservation.User = await _userManager.FindByNameAsync(User.Identity.Name);
                reservation.RequestedFlightNum = flightid;
                return View(reservation);
            }
            else
            {
                Reservation reservation = new Reservation();
                reservation.RequestedFlightNum = flightid;
                ViewBag.UserNames = await GetAllCustomerUserNamesSelectList();
                return View("SelectCustomerForReservation", reservation);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Manager,Agent")]
        public async Task<IActionResult> SelectCustomerForReservation(String SelectedCustomer, Reservation flightReservation)
        {
            if (String.IsNullOrEmpty(SelectedCustomer))
            {
                ViewBag.UserNames = await GetAllCustomerUserNamesSelectList();
                return View("SelectCustomerForReservation");
            }

            Reservation reservation = new Reservation();
            reservation.User = await _userManager.FindByNameAsync(SelectedCustomer);
            reservation.RequestedFlightNum = flightReservation.RequestedFlightNum;
            return View("Create", reservation);
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation reservation)
        {

            //string errorMessage = TempData["ErrorMessage"] as String;

            // Set the ViewBag message based on whether TempData contains the error message
            //ViewBag.Message = !string.IsNullOrEmpty(errorMessage) ? errorMessage : "No errors at this time!";

            Reservation res = new Reservation();
            AppUser dbAppUser = await _userManager.FindByNameAsync(reservation.User.UserName);

            res.User = dbAppUser;
            //Find the next registration number from the utilities class
            res.ReservationNumber = Utilities.GenerateNextReservationNumber.GetNextReservationNumber(_context);

            //Set the date of this order
            res.ReservationStatus = ReservationStatus.Pending;
            res.PaymentType = reservation.PaymentType;

            //Associate the registration with the logged-in customer
            //reservation.User = await _userManager.FindByNameAsync(reservation.User.UserName);
            res.MilesDeduction = 0;
            //res.Subtotal = 0;
            //res.Tax = 0;
            //res.Total = 0;

            res.RequestedFlightNum = reservation.RequestedFlightNum;

            //if code gets this far, add the registration to the database
            _context.Add(res);
            await _context.SaveChangesAsync();

            //send the user on to the action that will allow them to 
            //create a registration detail.  Be sure to pass along the RegistrationID
            //that you created when you added the registration to the database above
            return RedirectToAction("Details", new { id = res.ReservationID, requestedFlightNumParam = reservation.RequestedFlightNum });
        }

        // GET: Reservation/Edit/5
        public async Task<IActionResult> Edit(int? id, Int32? flightId)
        {
            if (id == null)
            {
                return NotFound();
            }


            var reservation = await _context.Reservations
                .Include(r => r.User)
                .Include(r => r.Tickets)
                    .ThenInclude(t => t.Flight)
                        .ThenInclude(f => f.FlightPath) // Include FlightPath
                    .Include(r => r.Tickets) // Include tickets
                        .ThenInclude(t => t.TicketHolder) // Include TicketHolder (assuming this is AppUser)
                .FirstOrDefaultAsync(r => r.ReservationID == id);

            reservation.RequestedFlightNum = flightId;

            if (User.IsInRole("Customer") && reservation.User.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not the reservation holder. Please contact the reservation holder to make any changes" });
            }

            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);


        }

        // POST: Reservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Reservation/Edit/
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reservation reservation)
        {
            if (id != reservation.ReservationID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the existing reservation from the database including its related entities
                    var existingReservation = await _context.Reservations
                        .Include(r => r.Tickets)
                        .FirstOrDefaultAsync(r => r.ReservationID == id);
                    // Update the scalar properties of the existing reservation
                    existingReservation.PaymentType = reservation.PaymentType;
                    // Update any other scalar properties here...
                    // If you want to update the Tickets property, you can do it here
                    // For example:
                    // existingReservation.Tickets = reservation.Tickets;
                    // Calculate the subtotal, tax, and total based on the updated reservation
                    existingReservation.CalculateMilesDeduction();
                    existingReservation.AddMiles();
                    existingReservation.ExpenseMiles();
                    // Update the reservation in the database
                    _context.Update(existingReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationID))
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
            return View(reservation);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind(“ResID,PaymentType,Subtotal,Tax,Total,MilesDeduction”)] Reservation reservation)
        //{
        //    if (id != reservation.ReservationID)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(reservation);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ReservationExists(reservation.ReservationID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(reservation);
        //}

        // GET: Reservation/Delete/5
        //[Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Redirect to a login page or show an error message
                return RedirectToAction("Login", "Account"); // Assuming "Login" action and "Account" controller
            }

            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.User) // Include user data to check user identity
                .FirstOrDefaultAsync(r => r.ReservationID == id);

            if (reservation == null)
            {
                return NotFound();
            }

            // Check if the user is authorized to delete the reservation
            if (User.IsInRole("Customer") && !User.Identity.Name.Equals(reservation.User.UserName))
            {
                return View("Error", new String[] { "You are not authorized to delete this reservation." });
            }

            return View(reservation);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var reservation = await _context.Reservations
                    .Include(r => r.Tickets)
                    .ThenInclude(t => t.TicketHolder)
                    .Include(r => r.User)
                    .Include(f => f.Tickets)
                    .ThenInclude(t => t.Flight)
                    .FirstOrDefaultAsync(r => r.ReservationID == id);

                if (reservation != null)
                {
                    reservation.ReservationStatus = ReservationStatus.Canceled;
                    foreach (var ticket in reservation.Tickets)
                    {
                        string primaryTravelerEmail = ticket.Reservation.User.Email;
                        if (ticket.TicketStatus == TicketStatus.Active)
                        {
                            ticket.TicketStatus = TicketStatus.Canceled;
                            if (ticket.Reservation.PaymentType == PaymentType.Cash)
                            {
                                // For Cash payment, include a message about refund
                                ticket.TicketStatus = TicketStatus.Canceled;
                                // Send email notification about refund
                                string cashRefundMessage = $"Hello {ticket.Reservation.User.FirstName} {ticket.Reservation.User.LastName},\n\nYour flight reservation (Paid in Cash) for Flight: {ticket.Flight.FlightNumber} has been canceled for {ticket.Flight.DepartureTime}. The ticket for {ticket.TicketHolder.FirstName} has been cancelled and you will receive your cash refund soon for ${ticket.Price}.\n\n Please be sure to create your reservation again. When Longhorn Airlines is forced to cancel flights, customers are responsible for making a new reservation according to our policy. \n\n Thank you and fly again with us! ";
                                Utilities.EmailMessaging.SendEmail("Reservation Cancellation - Cash Refund", cashRefundMessage, primaryTravelerEmail);
                            }
                            else if (ticket.Reservation.PaymentType == PaymentType.Miles)
                            {
                                // For Miles payment, add the miles back to the customer's account
                                ticket.TicketStatus = TicketStatus.Canceled;
                                ticket.Reservation.User.Miles += (int)ticket.PriceInMiles;
                                // Send email notification about miles added back
                                string milesRefundMessage = $"Hello {ticket.Reservation.User.FirstName} {ticket.Reservation.User.LastName},\n\nYour flight reservation (Paid in Miles) for Flight: {ticket.Flight.FlightNumber} has been canceled for {ticket.Flight.DepartureTime}. The ticket for {ticket.TicketHolder.FirstName} has been cancelled and {ticket.PriceInMiles} miles have been added back to your account. \n\n Please be sure to create your reservation again. When Longhorn Airlines is forced to cancel flights, customers are responsible for making a new reservation according to our policy. \n\n Thank you and fly again with us! ";
                                Utilities.EmailMessaging.SendEmail("Reservation Cancellation - Miles Refund", milesRefundMessage, primaryTravelerEmail);
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

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationID == id);
        }

        [HttpGet]
        public IActionResult DetailedSearch()
        {
            return View("DetailedSearch");
        }


        [HttpPost]
        public IActionResult DisplaySearchResults(ReservationSearchView searchViewModel)
        {
            if (searchViewModel == null)
            {
                // Handle null searchViewModel
                return BadRequest("Search criteria is required.");
            }

            IQueryable<Reservation> query = _context.Reservations
                .Include(r => r.Tickets)
                .ThenInclude(t => t.Flight);

            //PAYMENT INFORMATION
            // Payment Type Search
            if (searchViewModel.PaymentType.HasValue)
                query = query.Where(r => r.PaymentType == searchViewModel.PaymentType);

            // Price Search
            if (searchViewModel.PriceCriteria.HasValue)
            {
                if (searchViewModel.PriceCriteria == PriceCriteria.GreaterThan)
                {
                    query = query.Where(r => r.Total > searchViewModel.Total);
                }
                else if (searchViewModel.PriceCriteria == PriceCriteria.LessThan)
                {
                    query = query.Where(r => r.Total < searchViewModel.Total);
                }
            }
            // Email Search
            if (!string.IsNullOrEmpty(searchViewModel.Email))
            {
                query = query.Where(r => r.User.Email == searchViewModel.Email);
            }

            // Advantage Number Search
            if (searchViewModel.AdvantageNumber.HasValue)
            {
                query = query.Where(r => r.User.AdvantageNumber == searchViewModel.AdvantageNumber);
            }

            //    // Reservation Number
            if (searchViewModel.ReservationNumber.HasValue)
            {
                query = query.Where(r => r.ReservationNumber == searchViewModel.ReservationNumber);
            }

            //    //add code

            //TICKET INFORMATION
            // First Name Search
            if (!string.IsNullOrEmpty(searchViewModel.TicketholderFN))
            {
                query = query.Where(r => r.Tickets.Any(t => t.TicketHolder.FirstName.Contains(searchViewModel.TicketholderFN)));
            }

            // Last Name Search
            if (!string.IsNullOrEmpty(searchViewModel.TicketholderLN))
            {
                query = query.Where(r => r.Tickets.Any(t => t.TicketHolder.LastName.Contains(searchViewModel.TicketholderLN)));
            }

            //Flight Departure Search
            if (searchViewModel.BeforeAfter.HasValue && searchViewModel.DepartureTime.HasValue)
            {
                if (searchViewModel.BeforeAfter == BeforeAfter.Before)
                {
                    query = query.Where(r => r.Tickets.Any(t => t.Flight.DepartureTime < searchViewModel.DepartureTime));
                }
                else if (searchViewModel.BeforeAfter == BeforeAfter.After)
                {
                    query = query.Where(r => r.Tickets.Any(t => t.Flight.DepartureTime > searchViewModel.DepartureTime));
                }
            }

            // Ticket ID Search
            if (searchViewModel.TicketID.HasValue)
            {
                query = query.Where(r => r.Tickets.Any(t => t.TicketID == searchViewModel.TicketID));
            }


            //FLIGHT INFORMATION
            // Departure City Search
            if (searchViewModel.DepartureCity.HasValue)
            {
                query = query.Where(r => r.Tickets.Any(t => t.Flight.FlightPath.DepartureCity == searchViewModel.DepartureCity));
            }

            // Arrival City Search
            if (searchViewModel.ArrivalCity.HasValue)
            {
                query = query.Where(r => r.Tickets.Any(t => t.Flight.FlightPath.ArrivalCity == searchViewModel.ArrivalCity));
            }


            var selectedReservations = query.ToList();

            ViewBag.TotalReservationsCount = _context.Reservations.Count();
            ViewBag.SelectedReservationCount = selectedReservations.Count;

            return View("Index", selectedReservations.OrderBy(r => r.ReservationID).ToList());
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

        [Authorize]
        public async Task<IActionResult> CheckoutReservation(int? id, int? ticketId)
        {
            //the user did not specify a registration to view
            if (id == null)
            {
                return View("Error", new String[] { "Please specify a registration to view!" });
            }

            //find the registration in the database
            Reservation reservation = await _context.Reservations
                                              .Include(r => r.User)
                                              .Include(r => r.Tickets)
                                                .ThenInclude(t => t.Flight)
                                                    .ThenInclude(f => f.FlightPath) // Include FlightPath
                                              .Include(r => r.Tickets) // Include tickets
                                                .ThenInclude(t => t.TicketHolder) // Include TicketHolder (assuming this is AppUser)
                                              .FirstOrDefaultAsync(r => r.ReservationID == id);
                                              

            //registration was not found in the database
            if (reservation == null)
            {
                return View("Error", new String[] { "This registration was not found!" });
            }

            //make sure this registration belongs to this user
            if (User.IsInRole("Customer") && reservation.User.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "This is not your reservation!  Don't be such a snoop!" });
            }

            //ViewBag.BasePrice = decimal.Parse(TempData["BaseFlightPrice"].ToString());
            //ViewBag.Upgrades = decimal.Parse(TempData["Upgrades"].ToString());

            decimal basePrice = decimal.TryParse(TempData["BaseFlightPrice"]?.ToString(), out decimal tempBasePrice) ? tempBasePrice : 0m;
            decimal upgrades = decimal.TryParse(TempData["Upgrades"]?.ToString(), out decimal tempUpgrades) ? tempUpgrades : 0m;
            decimal modificationFee = decimal.TryParse(TempData["ModificationFee"]?.ToString(), out decimal tempModFee) ? tempModFee : 0m;
            string changeSeatMessage = TempData["ChangeSeatMessage"]?.ToString();

            if (changeSeatMessage == null)
            {
                // Add your own message here
                changeSeatMessage = "No changes were made at this time.";
            }

            ViewBag.ChangeSeatMessage = changeSeatMessage;
            ViewBag.BasePrice = basePrice;
            ViewBag.Upgrades = upgrades;
            ViewBag.ModificationFee = modificationFee;

            Decimal numberOfMiles = 0m;

            ViewBag.NumberOfMiles = numberOfMiles;

            // Check if basePrice and upgrades are both zero
            if (basePrice == 0m && upgrades == 0m)
            {
                numberOfMiles = decimal.TryParse(TempData["MilesToPurchase"]?.ToString(), out decimal tempNumberOfMiles) ? tempNumberOfMiles : 0m;

                ViewBag.NumberOfMiles = numberOfMiles;
            }
            else
            {
                if (ViewBag.Upgrades == 0)
                {
                    ViewBag.Discounts = decimal.Parse(TempData["Discounts"].ToString());
                }
                else
                {
                    ViewBag.Discounts = 0;
                }
            }
            
            ViewBag.TicketId = ticketId;

            //Send the user to the details page
            return View("Confirm", reservation);
        }

        public async Task<IActionResult> Confirm(int? id, int? ticketId)
        {
            Ticket dbTicket = await _context.Tickets.FindAsync(ticketId);

            Reservation dbRes = await _context.Reservations
                                            .Include(r => r.User) // Include the User navigational property
                                            .Include(r => r.Tickets)
                                                .ThenInclude(t => t.Flight)
                                                    .ThenInclude(f => f.FlightPath)
                                            .Include(r => r.Tickets)
                                                .ThenInclude(t => t.TicketHolder)
                                            .FirstOrDefaultAsync(r => r.ReservationID == id);

            //Reservation dbRes = await _context.Reservations
            //    .Include(r => r.User)
            //    .FindAsync(id);
            // Check if the reservation and ticket exist
            if (dbRes == null || dbTicket == null)
            {
                return NotFound(); // Or handle the case where either the reservation or ticket is not found
            }

            // Check if the ticket's flight matches the flight of any other ticket on the reservation
            bool flightMisMatchFound = false;
            bool sameSeatsFound = false;
            bool UserOnFlightAlready = false;
            bool UserOnConflictingFlight = false;
            var userTickets = _context.Tickets
                .Include(t => t.Flight)
                .ThenInclude(f => f.FlightPath)
                .Where(t => t.TicketHolder == dbTicket.TicketHolder)
                .ToList();

            foreach (var tempticket in userTickets)
            {
                if (tempticket.TicketHolder == dbTicket.TicketHolder && tempticket.TicketStatus == TicketStatus.Active && tempticket.Flight.DepartureTime + tempticket.Flight.FlightPath.Duration > dbTicket.Flight.DepartureTime && dbTicket.Flight.DepartureTime > tempticket.Flight.DepartureTime)
                {
                    UserOnConflictingFlight = true;
                    break;
                }
                else if (tempticket.TicketHolder == dbTicket.TicketHolder && tempticket.TicketStatus == TicketStatus.Active && dbTicket.Flight.DepartureTime + dbTicket.Flight.FlightPath.Duration > tempticket.Flight.DepartureTime && tempticket.Flight.DepartureTime > dbTicket.Flight.DepartureTime)
                {
                    UserOnConflictingFlight = true;
                    break;
                }
            }

            // If no matching flight is found, handle the validation error
            if (UserOnConflictingFlight)
            {
                ViewBag.UserOnConflictingFlight = "This customer is already on a flight that conflicts with this one.";
                //("", "The ticket's flight does not match any other flight on the reservation.");
                // You may return a view indicating the error or handle it according to your application's logic
                return View("Details", dbRes);
            }

            foreach (var tempticket in userTickets)
            {
                if (tempticket.TicketHolder == dbTicket.TicketHolder && tempticket.Flight.FlightID == dbTicket.Flight.FlightID && tempticket.TicketStatus == TicketStatus.Active)
                {
                    UserOnFlightAlready = true;
                    break;
                }
            }

            // If no matching flight is found, handle the validation error
            if (UserOnFlightAlready)
            {
                ViewBag.ConcurrentFlightFound = "This customer already has a ticket on this flight.";
                //("", "The ticket's flight does not match any other flight on the reservation.");
                // You may return a view indicating the error or handle it according to your application's logic
                return View("Details", dbRes);
            }

            foreach (var tempticket in dbRes.Tickets)
            {
                if (tempticket.Flight.FlightID != dbTicket.Flight.FlightID)
                {
                    flightMisMatchFound = true;
                    break; // Exit the loop as soon as a match is found
                }
            }

            // If no matching flight is found, handle the validation error
            if (flightMisMatchFound)
            {
                ViewBag.FlightMisMatchError = "You may not check out until all flights on the reservation match.";
                //("", "The ticket's flight does not match any other flight on the reservation.");
                // You may return a view indicating the error or handle it according to your application's logic
                return View("Details", dbRes);
            }

            foreach (var tempticket in dbRes.Tickets)
            {
                // Skip the comparison if the current ticket is the same as the ticket being confirmed
                if (tempticket == dbTicket)
                {
                    continue;
                }

                if (tempticket.Seat == dbTicket.Seat)
                {
                    sameSeatsFound = true;
                    break; // Exit the loop as soon as a match is found
                }
            }

            // If no matching flight is found, handle the validation error
            if (sameSeatsFound)
            {
                ViewBag.SameSeatsError = "You may not check out until each seat is different.";
                //("", "The ticket's flight does not match any other flight on the reservation.");
                // You may return a view indicating the error or handle it according to your application's logic
                return View("Details", dbRes);
            }


            dbRes.MilesDeduction += (int)dbTicket.PriceInMiles;
            dbRes.User.Miles -= (int)dbTicket.PriceInMiles;
            dbRes.ReservationStatus = ReservationStatus.Completed;
            dbTicket.TicketStatus = TicketStatus.Active;

            _context.Update(dbTicket);
            _context.SaveChanges();

            _context.Update(dbRes);
            _context.SaveChanges();



            //------------------------------------------------------------------------------------
            //Ticket ticket = await _context.Tickets
            //                  .Include(tk => tk.Flight)
            //                  .ThenInclude(f => f.FlightPath)
            //                  .Include(tk => tk.Reservation)
            //                  .FirstOrDefaultAsync(tk => tk.TicketID == ticketId);

            //try
            //{
            //    if (ticket.Reservation.PaymentType == PaymentType.Cash)
            //    {
            //        String emailBody = "Hello!\n\nThank you for your reservation (Paid in Cash) \n\n Course: " + ticket.Flight.FlightID.ToString() + "\n\nTotal Cost: $" + ticket.Price;
            //        Utilities.EmailMessaging.SendEmail("Longhorn Airlines - Reservation Created", emailBody);
            //    }
            //    else
            //    {
            //        String emailBody = "Hello!\n\nThank you for your reservation (Paid in Miles) \n\n Course: " + ticket.Flight.FlightID.ToString() + "\n\nTotal Cost: $" + ticket.PriceInMiles;
            //        Utilities.EmailMessaging.SendEmail("Longhorn Airlines - Reservation Created", emailBody);
            //    }
            //}

            //catch (Exception ex)
            //{
            //    return View("Error", new String[] { "There was a problem sending the email", ex.Message });
            //}
            //--------------------------------------------------------------------------------------------------------------------


            // Ensure that the Ticket object is properly retrieved from the database
            Ticket ticket = await _context.Tickets
                .Include(tk => tk.Flight)
                .ThenInclude(th => th.FlightPath)
                .Include(tk => tk.TicketHolder)
                .Include(tk => tk.Reservation)
                .FirstOrDefaultAsync(tk => tk.TicketID == ticketId);



            //try
            //{
            //    // Check if the ticket or associated objects are null
            //    if (ticket == null || ticket.TicketHolder == null || ticket.Flight == null || ticket.Flight.FlightPath == null || ticket.Reservation == null)
            //    {
            //        throw new Exception("Ticket information is incomplete.");
            //    }

            //    // Access the FlightPath associated with the TicketHolder (assuming it's part of the TicketHolder)
            //    // Primary traveler is the reserver
            //    string primaryTravelerEmail = ticket.Reservation.User.Email;

            //    string emailSubject = "";
            //    string emailBody = "";

            //    // Check if it's a new reservation or a seat update
            //    if (TempData["OriginalSeat"] == null)
            //    {
            //        // New reservation
            //        emailSubject = "Longhorn Airlines - New Reservation Created";

            //        if (ticket.Reservation.PaymentType == PaymentType.Cash)
            //        {
            //            emailBody = $"Hello {ticket.Reservation.User.FirstName},{ticket.Reservation.User.LastName},\n\nThank you for your reservation (Paid in Cash),\n\n You bought a ticket for {ticket.TicketHolder.FirstName} {ticket.TicketHolder.LastName} \n\nFlight: {ticket.Flight.FlightNumber}\n";
            //            emailBody += $"Seat: {ticket.Seat}  \n\nFlight Day and time: {ticket.Flight.DepartureTime}  \n\n Total Price: ${ticket.Price}";
            //        }
            //        else
            //        {
            //            emailBody = $"Hello {ticket.Reservation.User.FirstName},{ticket.Reservation.User.LastName},\n\nThank you for your reservation (Paid in Miles),\n\n You bought a ticket for {ticket.TicketHolder.FirstName} {ticket.TicketHolder.LastName} \n\nFlight: {ticket.Flight.FlightNumber}\n";
            //            emailBody += $"Seat: {ticket.Seat}  \n\nFlight Day and time: {ticket.Flight.DepartureTime} \n\n Total Price in miles: {ticket.PriceInMiles} miles";
            //        }
            //    }
            //    else
            //    {
            //        // Seat update
            //        emailSubject = "Longhorn Airlines - Reservation Updated";

            //        // Retrieve original seat information from TempData
            //        string originalSeat = TempData["OriginalSeat"]?.ToString();

            //        emailBody = $"Hello {ticket.Reservation.User.FirstName},{ticket.Reservation.User.LastName},\n\nYour reservation has been updated:\n\nOriginal Seat: {originalSeat}\nNew Seat: {ticket.Seat}\n\nFlight: {ticket.Flight.FlightNumber}\nFlight Day and time: {ticket.Flight.DepartureTime}";

            //        if (ticket.Reservation.PaymentType == PaymentType.Cash)
            //        {
            //            emailBody += $"\nTotal Price: ${ticket.Price}";
            //        }
            //        else
            //        {
            //            emailBody += $"\nTotal Price in miles: {ticket.PriceInMiles} miles";
            //        }
            //    }

            //    // Send email
            //    Utilities.EmailMessaging.SendEmail(emailSubject, emailBody, primaryTravelerEmail);

            //    // For secondary travelers
            //    foreach (var secondaryTraveler in ticket.Reservation.Tickets.Where(t => t.TicketID != ticket.TicketID))
            //    {
            //        if (secondaryTraveler.TicketHolder == null)
            //        {
            //            throw new Exception("Secondary traveler information is incomplete.");
            //        }

            //        // Access the FlightPath associated with the TicketHolder of each secondary traveler
            //        string secondaryTravelerEmail = secondaryTraveler.TicketHolder.Email;
            //        string secondaryTravelerBody = $"Hello {secondaryTraveler.TicketHolder.FirstName},\n\nYou have been added to a group reservation. Here are the details:\n\nFlight: {ticket.Flight.FlightNumber}\nSeat: {secondaryTraveler.Seat}";
            //        Utilities.EmailMessaging.SendEmail("Longhorn Airlines - Group Reservation Created", secondaryTravelerBody, secondaryTravelerEmail);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return View("Error", new string[] { "There was a problem sending the email", ex.Message });
            //}


            try
            {
                // Check if the ticket or associated objects are null
                if (ticket == null || ticket.TicketHolder == null || ticket.Flight == null || ticket.Flight.FlightPath == null || ticket.Reservation == null)
                {
                    throw new Exception("Ticket information is incomplete.");
                }

                // Access the FlightPath associated with the TicketHolder (assuming it's part of the TicketHolder)
                // Primary traveler is the reserver
                string primaryTravelerEmail = ticket.Reservation.User.Email;



                if (ticket.Reservation.PaymentType == PaymentType.Cash)
                {
                    string primaryTravelerBody = $"Hello Reservation Holder {ticket.Reservation.User.FirstName} {ticket.Reservation.User.LastName},\n\nThank you for your reservation (Paid in Cash),\n\n You bought a ticket for {ticket.TicketHolder.FirstName} {ticket.TicketHolder.LastName} \n\nFlight: {ticket.Flight.FlightNumber}\nSeat: {ticket.Seat}  \n\nFlight Day and time: {ticket.Flight.DepartureTime}  \n\n Total Price: ${ticket.Price}";
                    Utilities.EmailMessaging.SendEmail("Longhorn Airlines - Reservation Confirmation", primaryTravelerBody, primaryTravelerEmail);
                }
                else
                {
                    string primaryTravelerBody = $"Hello Reservation Holder {ticket.Reservation.User.FirstName} {ticket.Reservation.User.LastName},\n\nThank you for your reservation (Paid in Miles),\n\n You bought a ticket for {ticket.TicketHolder.FirstName} {ticket.TicketHolder.LastName} \n\nFlight: {ticket.Flight.FlightNumber}\nSeat: {ticket.Seat}  \n\nFlight Day and time: {ticket.Flight.DepartureTime} \n\n Total Price in miles: {ticket.PriceInMiles} miles";
                    Utilities.EmailMessaging.SendEmail("Longhorn Airlines - Reservation Confirmation", primaryTravelerBody, primaryTravelerEmail);
                }


                // For secondary travelers
                foreach (var secondaryTraveler in ticket.Reservation.Tickets.Where(t => t.TicketID != ticket.TicketID))
                {
                    if (secondaryTraveler.TicketHolder == null)
                    {
                        throw new Exception("Secondary traveler information is incomplete.");
                    }

                    // Access the FlightPath associated with the TicketHolder of each secondary traveler
                    string secondaryTravelerEmail = secondaryTraveler.TicketHolder.Email;
                    string secondaryTravelerBody = $"Hello {secondaryTraveler.TicketHolder.FirstName},\n\nYou have been added to a group reservation. Here are the details:\n\nFlight: {ticket.Flight.FlightNumber}\nSeat: {secondaryTraveler.Seat}";
                    Utilities.EmailMessaging.SendEmail("Longhorn Airlines - Group Reservation Info", secondaryTravelerBody, secondaryTravelerEmail);
                }

            }
            catch (Exception ex)
            {
                return View("Error", new string[] { "There was a problem sending the email", ex.Message });
            }


            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult TogglePaymentType(int reservationId)
        {
            // Retrieve the reservation from the database
            var reservation = _context.Reservations.Find(reservationId);

            // Toggle the payment type
            if (reservation.PaymentType == PaymentType.Cash)
            {
                reservation.PaymentType = PaymentType.Miles;
            }
            else
            {
                reservation.PaymentType = PaymentType.Cash;
            }

            _context.SaveChanges();

            // Redirect back to the edit view
            return RedirectToAction("Edit", new { id = reservationId });
        }


    }
}
