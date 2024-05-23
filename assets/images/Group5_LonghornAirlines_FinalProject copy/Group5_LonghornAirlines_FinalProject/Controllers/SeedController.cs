using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


//Update this using statement to include your project name
using Group5_LonghornAirlines_FinalProject.Models;
using Group5_LonghornAirlines_FinalProject.Seeding;
using Group5_LonghornAirlines_FinalProject.DAL;
using System;
using Microsoft.EntityFrameworkCore;

//TUpddate this namespace to match your project name
namespace Group5_LonghornAirlines_FinalProject.Controllers
{
    public class SeedController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedController(AppDbContext db, UserManager<AppUser> um, RoleManager<IdentityRole> rm)
        {
            _context = db;
            _userManager = um;
            _roleManager = rm;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DeleteAllRecords()
        {

          await _context.Tickets.ExecuteDeleteAsync();
          await _context.Reservations.ExecuteDeleteAsync();
          await _context.Flights.ExecuteDeleteAsync();
          await _context.Users.ExecuteDeleteAsync();
          await _context.FlightPaths.ExecuteDeleteAsync();


            return View("Confirm");
        }


        public async Task<IActionResult> SeedRoles()
        {
            try
            {
                //call the method to seed the roles
                await Seeding.SeedRoles.AddAllRoles(_roleManager);

            }
            catch (Exception ex)
            {
                //add the error messages to a list of strings
                List<String> errorList = new List<String>();

                //Add the outer message
                errorList.Add(ex.Message);

                //Add the message from the inner exception
                errorList.Add("There was an error");

                return View("Error", errorList);
            }

            //this is the happy path - seeding worked!
            return View("Confirm");
        }
        public async Task<IActionResult> SeedEverythingElse()
        {
            try
            {
                //call the method to seed the users
                await Seeding.SeedUsers.SeedAllUsers(_userManager, _context);
            }
            catch (Exception ex)
            {
                //add the error messages to a list of strings
                List<String> errorList = new List<String>();

                //Add the outer message
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    //Add the message from the inner exception
                    errorList.Add(ex.InnerException.Message);

                    //Add additional inner exception messages, if there are any
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }

                }
                return View("Error", errorList);

            }
            Seeding.SeedFlightPaths.SeedAllFlightPaths(_context);

            Seeding.SeedFlights.SeedAllFlights(_context);

            Seeding.SeedReservations.SeedAllReservations(_context);

            Seeding.SeedTickets.SeedAllTickets(_context);


            //this is the happy path - seeding worked!
            return View("Confirm");
        }
    }
}
