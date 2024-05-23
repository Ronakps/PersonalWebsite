using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

//Upddate this namespace to match your project name
namespace Group5_LonghornAirlines_FinalProject.Seeding
{
    public class SeedRoles
    {
        public static async Task AddAllRoles(RoleManager<IdentityRole> roleManager)
        {
            //Add the needed roles - admin and customer are provided
            //as examples
            //if the admin role doesn't exist, add it
            if (await roleManager.RoleExistsAsync("Manager") == false)
            {
                //this code uses the role manager object to create the admin role
                await roleManager.CreateAsync(new IdentityRole("Manager"));
            }

            if (await roleManager.RoleExistsAsync("Agent") == false)
            {
                //this code uses the role manager object to create the admin role
                await roleManager.CreateAsync(new IdentityRole("Agent"));
            }

            //if the customer role doesn't exist, add it
            if (await roleManager.RoleExistsAsync("Customer") == false)
            {
                //this code uses the role manager object to create the customer role
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }

        }
    }
}


