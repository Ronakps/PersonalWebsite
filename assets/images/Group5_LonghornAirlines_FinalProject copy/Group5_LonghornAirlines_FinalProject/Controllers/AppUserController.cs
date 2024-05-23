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
using Group5_LonghornAirlines_FinalProject.Utilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;
using Microsoft.AspNetCore.Authorization;


namespace Group5_LonghornAirlines_FinalProject.Controllers
{
    public class AppUserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AppUserController(AppDbContext context, UserManager<AppUser> userManger)
        {
            _context = context;
            _userManager = userManger;
        }

        // GET: AppUser
        [Authorize]
        public async Task<IActionResult> Index(string searchString)
        {
            var query = from u in _context.Users
                        where u.AdvantageNumber != null
                        select u;

            // Apply search filter if searchString is not null or empty
            if (!string.IsNullOrEmpty(searchString))
            {
                // Modify the query to filter by FirstName, LastName, or MiddleInitial
                query = query.Where(u => u.FirstName.Contains(searchString) ||
                                          u.LastName.Contains(searchString));
            }

            // Order the users by FirstName
            query = query.OrderBy(u => u.FirstName);

            // Execute the query
            var customers = await query.ToListAsync();

            // Populate the ViewBag with a count of all users who are customers (have AdvantageNumber)
            ViewBag.TotalUsersCount = _context.Users.Count(u => u.AdvantageNumber != null);

            // Populate the ViewBag with a count of selected users (customers)
            ViewBag.SelectedUsersCount = customers.Count;

            return View(customers);
        }

        [Authorize(Roles = "Manager,Agent")]
        public async Task<IActionResult> Employees(string searchString)
        {
            var query = from u in _context.Users
                        where u.AdvantageNumber == null
                        select u;

            // Apply search filter if searchString is not null or empty
            if (!string.IsNullOrEmpty(searchString))
            {
                // Modify the query to filter by FirstName or LastName
                query = query.Where(u => u.FirstName.Contains(searchString) ||
                                          u.LastName.Contains(searchString));
            }

            // Order the users by FirstName
            query = query.OrderBy(u => u.FirstName);

            // Execute the query
            var employees = await query.ToListAsync();

            // Populate the ViewBag with a count of all users who are employees (have no AdvantageNumber)
            ViewBag.TotalUsersCount = _context.Users.Count(u => u.AdvantageNumber == null);

            // Populate the ViewBag with a count of selected users (employees)
            ViewBag.SelectedUsersCount = employees.Count;

            return View(employees);
        }




        // GET: AppUser/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.Users
                .Include(u => u.Tickets)
                .ThenInclude(t => t.Flight)
                .FirstOrDefaultAsync(m => m.Id == id);

            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if (appUser == null)
            {
                return NotFound();
            }

            //if (appUser.Id != currentUser.Id && currentUser.)

            if (User.IsInRole("Customer"))
            {
                if (appUser.Id != currentUser.Id)
                {
                    return View("Error", new String[] { "This is not you!  Don't be such a snoop!" });
                }
            }


            // Check roles for the user
            var isCustomer = await _userManager.IsInRoleAsync(appUser, "Customer");

            // Use ViewBag or ViewData to pass role information to the view
            ViewBag.IsCustomer = isCustomer;

            return View(appUser);
        }


        // GET: AppUser/Create
        public IActionResult Create()
        {
            return RedirectToAction("Register", "Account");
        }


        public IActionResult DetailedSearch()
        {
            return View("DetailedSearch");

        }

        public IActionResult DetailedEmployeeSearch()
        {
            return View("DetailedEmployeeSearch");

        }

        //TESTING DETAILED SEARCH ------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult DisplaySearchResults(AppUserViewModel viewModel)
        {
            var query = from u in _context.Users
                        where u.AdvantageNumber != null
                        select u;
            // Apply search filters based on the provided search criteria

            if (!string.IsNullOrEmpty(viewModel.FirstName))
            {
                query = query.Where(u => u.FirstName.Contains(viewModel.FirstName));
            }

            if (!string.IsNullOrEmpty(viewModel.LastName))
            {
                query = query.Where(u => u.LastName.Contains(viewModel.LastName));
            }

            if (!string.IsNullOrEmpty(viewModel.MiddleInitial))
            {
                query = query.Where(u => u.MiddleInitial == viewModel.MiddleInitial);
            }

            if (viewModel.DateOfBirth.HasValue)
            {
                query = query.Where(u => u.DateOfBirth == viewModel.DateOfBirth);
            }

            if (viewModel.ActiveStatus)
            {
                query = query.Where(u => u.ActiveStatus == true);
            }

            if (viewModel.AdvantageNumber.HasValue)
            {
                query = query.Where(u => u.AdvantageNumber == viewModel.AdvantageNumber);
            }

            if (viewModel.Miles.HasValue)
            {
                query = query.Where(u => u.Miles == viewModel.Miles);
            }

            if (!string.IsNullOrEmpty(viewModel.Email))
            {
                query = query.Where(u => u.Email.Contains(viewModel.Email));
            }

            List<AppUser> users = query.ToList();

            // Populate the ViewBag with a count of all flights
            ViewBag.TotalUsersCount = _context.Users.Count(u => u.AdvantageNumber != null);

            // Populate the ViewBag with a count of selected flights
            ViewBag.SelectedUsersCount = users.Count;

            return View("Index", users);
        }

        //TESTING DETAILED SEARCH ------------------------------------------------------------------------------------------------------------------



        //TESTING DETAILED EMPLOYEE SEARCH ------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult DisplayEmployeeSearchResults(AppUserViewModel viewModel)
        {
            var query = from u in _context.Users
                        where u.AdvantageNumber == null
                        select u;

            // Apply search filters based on the provided search criteria

            if (!string.IsNullOrEmpty(viewModel.FirstName))
            {
                query = query.Where(u => u.FirstName.Contains(viewModel.FirstName));
            }

            if (!string.IsNullOrEmpty(viewModel.LastName))
            {
                query = query.Where(u => u.LastName.Contains(viewModel.LastName));
            }

            if (!string.IsNullOrEmpty(viewModel.MiddleInitial))
            {
                query = query.Where(u => u.MiddleInitial == viewModel.MiddleInitial);
            }

            if (viewModel.DateOfBirth.HasValue)
            {
                query = query.Where(u => u.DateOfBirth == viewModel.DateOfBirth);
            }

            if (viewModel.ActiveStatus)
            {
                query = query.Where(u => u.ActiveStatus == true);
            }

            if (!string.IsNullOrEmpty(viewModel.Email))
            {
                query = query.Where(u => u.Email.Contains(viewModel.Email));
            }

            List<AppUser> users = query.ToList();

            // Populate the ViewBag with a count of all users who are employees (have no AdvantageNumber)
            ViewBag.TotalUsersCount = _context.Users.Count(u => u.AdvantageNumber == null);

            // Populate the ViewBag with a count of selected users (employees)
            ViewBag.SelectedUsersCount = users.Count;

            return View("Employees", users);
        }

        //TESTING DETAILED EMPLOYEE SEARCH ------------------------------------------------------------------------------------------------------------------





        // POST: AppUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,MiddleInitial,DateOfBirth,Street,City,Zip,State,ActiveStatus,Age,AdvantageNumber,Miles,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                appUser.ActiveStatus = true;
                _context.Add(appUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        // GET: AppUser/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve user from UserManager asynchronously
            var appUser = await _userManager.FindByIdAsync(id);

            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if (appUser == null)
            {
                return NotFound();
            }

            //if (appUser.Id != currentUser.Id && currentUser.)

            if (User.IsInRole("Customer"))
            {
                if (appUser.Id != currentUser.Id)
                {
                    return View("Error", new String[] { "This is not you!  Don't be such a snoop!" });
                }
            }


            // Map AppUser properties to EditUser view model
            var user = new EditUser
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                MiddleInitial = appUser.MiddleInitial,
                DateOfBirth = appUser.DateOfBirth,
                Street = appUser.Street,
                City = appUser.City,
                Zip = appUser.Zip,
                State = appUser.State,
                ActiveStatus = appUser.ActiveStatus

            };

            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditUser model)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByIdAsync(model.Id);

                if (appUser == null)
                {
                    return NotFound();
                }

                // Update the properties of the AppUser based on the EditUser model
                appUser.FirstName = model.FirstName;
                appUser.LastName = model.LastName;
                appUser.MiddleInitial = model.MiddleInitial;
                appUser.DateOfBirth = model.DateOfBirth;
                appUser.Street = model.Street;
                appUser.City = model.City;
                appUser.Zip = model.Zip;
                appUser.State = model.State;
                appUser.ActiveStatus = model.ActiveStatus;

                // Update the AppUser in the database
                var result = await _userManager.UpdateAsync(appUser);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index"); // Redirect to a success page or action
                }
                else
                {
                    // If update failed, add errors to ModelState and return to the edit view
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
            }
            return View(model); // If model state is not valid, return to the edit view with validation errors
        }






        //// GET: AppUser/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var appUser = await _context.Users
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (appUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(appUser);
        //}

        //// POST: AppUser/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var appUser = await _context.Users.FindAsync(id);
        //    if (appUser != null)
        //    {
        //        _context.Users.Remove(appUser);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool AppUserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }


        // GET: Reservation/BookReservation/5
        public async Task<IActionResult> BookReservation(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Store the Id of the AppUser in TempData
            TempData["ManagerReserver"] = id;

            // Redirect to the Index action of FlightsController
            return RedirectToAction("Index", "Flights");
        }




    }
}

