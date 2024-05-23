using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

//Change these using statements to match your project
using Group5_LonghornAirlines_FinalProject.Models;

//Change this namespace to match your project
namespace Group5_LonghornAirlines_FinalProject.Controllers
{
    //TODO: Uncomment this line once you have roles working correctly
    [Authorize(Roles = "Manager")]
    public class RoleAdminController : Controller
    {
        //create private variables for the services needed in this controller
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        //RoleAdminController constructor
        public RoleAdminController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //populate the values of the variables passed into the controller
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: /RoleAdmin/
        public async Task<ActionResult> Index()
        {
            List<RoleEditModel> roles = new List<RoleEditModel>();

            // Get only specific users
            var relevantUsers = _userManager.Users.ToList().Where(user =>
                _userManager.IsInRoleAsync(user, "Manager").Result ||
                _userManager.IsInRoleAsync(user, "Agent").Result).ToList();

            foreach (IdentityRole role in _roleManager.Roles)
            {
                if (role.Name == "Customer")
                    continue;

                List<AppUser> RoleMembers = new List<AppUser>();
                List<AppUser> RoleNonMembers = new List<AppUser>();

                foreach (AppUser user in relevantUsers)
                {
                    bool isInRole = await _userManager.IsInRoleAsync(user, role.Name);
                    if (isInRole)
                    {
                        RoleMembers.Add(user);
                    }
                    else
                    {
                        RoleNonMembers.Add(user);
                    }
                }

                RoleEditModel rem = new RoleEditModel
                {
                    Role = role,
                    RoleMembers = RoleMembers,
                    RoleNonMembers = RoleNonMembers
                };

                roles.Add(rem);
            }

            return View(roles);
        }



        public async Task<ActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            if (role.Name == "Customer")
                return View("Error", new string[] { "Access Denied: Cannot edit 'Customer' role." });

            // Get only specific users
            var relevantUsers = _userManager.Users.ToList().Where(user =>
                _userManager.IsInRoleAsync(user, "Manager").Result ||
                _userManager.IsInRoleAsync(user, "Agent").Result).ToList();

            List<AppUser> RoleMembers = new List<AppUser>();
            List<AppUser> RoleNonMembers = new List<AppUser>();

            foreach (AppUser user in relevantUsers)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    RoleMembers.Add(user);
                }
                else
                {
                    RoleNonMembers.Add(user);
                }
            }

            RoleEditModel rem = new RoleEditModel
            {
                Role = role,
                RoleMembers = RoleMembers,
                RoleNonMembers = RoleNonMembers
            };

            return View(rem);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleModificationModel rmm)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                // Process additions
                if (rmm.IdsToAdd != null)
                {
                    foreach (string userId in rmm.IdsToAdd)
                    {
                        AppUser user = await _userManager.FindByIdAsync(userId);
                        result = await _userManager.AddToRoleAsync(user, rmm.RoleName);
                        if (!result.Succeeded)
                        {
                            return View("Error", result.Errors);
                        }
                    }
                }

                // Process deletions
                if (rmm.IdsToDelete != null)
                {
                    foreach (string userId in rmm.IdsToDelete)
                    {
                        AppUser user = await _userManager.FindByIdAsync(userId);

                        // Remove the user from the specified role
                        result = await _userManager.RemoveFromRoleAsync(user, rmm.RoleName);
                        if (!result.Succeeded)
                        {
                            return View("Error", result.Errors);
                        }

                        // Check if the role being removed is "Agent"
                        if (rmm.RoleName == "Agent")
                        {
                            // Automatically add the user to the "Manager" role
                            result = await _userManager.AddToRoleAsync(user, "Manager");
                            if (!result.Succeeded)
                            {
                                return View("Error", result.Errors);
                            }
                        }
                        // Check if the role being removed is "Manager"
                        else if (rmm.RoleName == "Manager")
                        {
                            // Automatically add the user to the "Agent" role
                            result = await _userManager.AddToRoleAsync(user, "Agent");
                            if (!result.Succeeded)
                            {
                                return View("Error", result.Errors);
                            }
                        }
                    }
                }

                // Redirect back to the RoleAdmin Index page on successful update
                return RedirectToAction("Index");
            }

            // If the model state is not valid, or the role does not exist
            return View("Error", new string[] { "Role Not Found" });
        }



    }

}